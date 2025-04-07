using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Parysn.Apps.Admin.UIServices.Auth
{
    public class AuthServiceProvider(IConfiguration configuration) : AuthenticationStateProvider
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly string _secretKey = configuration["Jwt:Key"];
        private readonly string _issuer = configuration["Jwt:Issuer"];
        private readonly string _audience = configuration["Jwt:Audience"];
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var response = await _httpClient.GetAsync("api/auth/user");
            //if (response.IsSuccessStatusCode)
            //{
            //    var user = await response.Content.ReadFromJsonAsync<ClaimsPrincipal>();
            //    return new AuthenticationState(user);
            //}

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public void NotifyUserAuthentication(string token)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, "User") };
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }
    }
}
