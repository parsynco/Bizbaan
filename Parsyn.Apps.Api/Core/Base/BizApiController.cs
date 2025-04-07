using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Parsyn.Apps.Api.Core.Base
{
    [Authorize]
    public class BizApiController : ControllerBase
    {
    }
}
