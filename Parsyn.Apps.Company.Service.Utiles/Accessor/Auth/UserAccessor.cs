using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Accessor.Auth
{
    public class UserAccessor(IHttpContextAccessor httpContextAccessor) : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public ClaimsPrincipal User()
        {
            return _httpContextAccessor.HttpContext?.User;
        }
    }
}
