using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Middlewares
{
    public class AuthMiddleware(RequestDelegate next,
   ILogger<AuthMiddleware> logger,
   IConfiguration configuration)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<AuthMiddleware> _logger = logger;
        private readonly string _secretKey = configuration["Jwt:Key"];
        private readonly string _issuer = configuration["Jwt:Issuer"];
        private readonly string _audience = configuration["Jwt:Audience"];

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_secretKey);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _issuer,
                        ValidateAudience = true,
                        ValidAudience = _audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var claims = jwtToken.Claims;

                    var identity = new ClaimsIdentity(claims, "jwt");
                    context.User = new ClaimsPrincipal(identity);

                    await _next(context);
                    return;
                }
                catch (SecurityTokenException ex)
                {
                    await _next(context);
                    _logger.LogError(ex, "JWT validation failed.");
                }
            }
            await _next(context);
            // If authentication fails or no token is present, return unauthorized
            //context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //await context.Response.WriteAsync("Unauthorized");
        }
    }
}
