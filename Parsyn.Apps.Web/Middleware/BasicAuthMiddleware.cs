using System.Text;

namespace Parsyn.Apps.Web.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string Username = "admin@bizbaan.com"; // Replace with your desired username
        private const string Password = "Bizbaan@2024"; // Replace with your desired password
        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains(".json") || context.Request.Path.Value.Contains(".manifest"))
            {
                await _next(context);
            }
            // Check if the request is from a Google crawler
            var userAgent = context.Request.Headers["User-Agent"].ToString();
            if (IsGoogleCrawler(userAgent))
            {
                await _next(context); // Allow access to Google crawlers
                return;
            }

            // Check for basic authentication for all other requests
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401; // Unauthorized
                context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted Area\"");
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                var usernamePasswordArray = decodedUsernamePassword.Split(':');

                if (usernamePasswordArray.Length == 2 &&
                    usernamePasswordArray[0] == Username &&
                    usernamePasswordArray[1] == Password)
                {
                    await _next(context); // Valid credentials, proceed to the next middleware
                    return;
                }
            }

            context.Response.StatusCode = 401; // Unauthorized
            context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted Area\"");
            await context.Response.WriteAsync("Unauthorized");
        }

        private bool IsGoogleCrawler(string userAgent)
        {
            // List of known Google crawler User-Agent strings
            var googleCrawlers = new[]
            {
            "Googlebot",
            "Googlebot-Image",
            "Googlebot-Video",
            "Googlebot-News",
            "AdsBot-Google"
        };

            // Check if the User-Agent matches any of the known Google crawler strings
            return googleCrawlers.Any(crawler => userAgent.Contains(crawler, StringComparison.OrdinalIgnoreCase));
        }
    }
}
