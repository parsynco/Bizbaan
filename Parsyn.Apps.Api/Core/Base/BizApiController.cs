using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Parsyn.Apps.Api.Core.Base
{
    [Authorize]
    [OutputCache(Duration = 120)]
    public class BizApiController : ControllerBase
    {
    }
}
