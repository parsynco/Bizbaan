using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Services.Interfaces;

namespace Parsyn.Apps.Api.Controllers.Admin.Auth
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, IUserIface srvc) : ControllerBase
    {
        IConfiguration _configuration = configuration;
        IUserIface _srvc = srvc;
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Signin(LoginDto model)
        {
            ConfigDto config = new() { 
                Key = _configuration["Jwt:Key"],
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var login = await _srvc.SignIn(HttpContext,model.Username,model.Password,config);
            return Ok(login);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("otp")]
        public async Task<ActionResult> RegenrateOtp(LoginDto model)
        {
            
            var login = await _srvc.GenOtpAndEmail(model.Username);
            return Ok(login);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("ValidateOtp")]
        public async Task<ActionResult> FinalizeLogin(LoginDto model)
        {
            
            var login = await _srvc.MakeSignin(HttpContext,model.Username,model.Otp);
            return Ok(login);
        }
    }
}
