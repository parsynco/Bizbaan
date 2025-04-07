using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Accessor.Auth
{
    public interface IUserAccessor
    {
        ClaimsPrincipal User();
    }
}
