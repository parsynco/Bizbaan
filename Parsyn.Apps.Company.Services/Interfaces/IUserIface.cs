using Microsoft.AspNetCore.Http;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IUserIface:IBaseIface<UserModel>
    {
        List<UserModel> GetAllInclude();
        Task<ResponseObject> SignIn(HttpContext httpContext, string username, string password, ConfigDto config);
        Task<ResponseObject> ToggleDisable(int id);
        Task<ResponseObject> ToggleBan(int id);
        Task<ResponseObject> ResetPwd(ResetPwdDto rpd);
        Task<ResponseObject> MakeSignin(HttpContext httpContext, string username, string? otp = null);
        Task<ResponseObject> GenOtpAndEmail(string username);
    }
}
