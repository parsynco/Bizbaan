using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Migrations;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Service.Utiles.Helpers;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parsyn.Apps.Company.Services.Services
{
    public class UserService(PDBContext ctx, ILogger log, IOtpGenerator otp, ITemplateEngine template, IEmailService email, IConfiguration conf) : BaseService<UserModel>(ctx, log), IUserIface
    {
        private IOtpGenerator _otp = otp;
        private ITemplateEngine _template = template;
        private IEmailService _email = email;
        private IConfiguration _conf = conf;
        private bool OtpIsActive { get; set; } = true;

        public void Init()
        {
            string otpstate = _conf["OTPSTATE"] ?? "false";
            OtpIsActive = bool.Parse(otpstate);
        }
        public new ResponseObject Add(UserModel model)
        {
            try
            {
                model.Password = PasswordHelper.Hash(model);
                return base.Add(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<UserModel> GetAllInclude()
        {
            return [.. _dbObj.Include(x => x.Role)];
        }

        public async Task<ResponseObject> SignIn(HttpContext httpContext, string username, string password, ConfigDto config)
        {
            try
            {
                Init();
                var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Email == username);
                if (fndUsr is null)
                {
                    return _rsp.MapError("Invalid Username or Password.");
                }
                if (fndUsr.IsDisabled)
                {
                    return _rsp.MapError("Your account is disabled. Contact administrator.");
                }
                if (fndUsr.IsBanned)
                {
                    return _rsp.MapError("Your account is Banned. Contact administrator.");
                }
                if (!PasswordHelper.Verify(fndUsr, password))
                {
                    fndUsr.FailAccessCount++;

                    if (fndUsr.FailAccessCount >= 3)
                    {
                        fndUsr.IsDisabled = true;
                        _dbObj.Update(fndUsr);
                        await _ctx.SaveChangesAsync();
                        return _rsp.MapError("Your account has been disabled. Contact administrator.");
                    }
                    _dbObj.Update(fndUsr);
                    await _ctx.SaveChangesAsync();
                    return _rsp.MapError("Invalid Creditional.");
                }
                JwtTokenHelper jwtToken = new(config.Key, config.Issuer, config.Audience);
                var token = jwtToken.GenerateToken(fndUsr);
                fndUsr.AuthToken = token;
                _dbObj.Update(fndUsr);
                await _ctx.SaveChangesAsync();
                if (OtpIsActive)
                {
                    return await GenOtpAndEmail(username);
                }


                return await MakeSignin(httpContext, username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<ResponseObject> GenOtpAndEmail(string username)
        {
            _email.Config("webmail.bizbaan.com", 25, "no-reply@bizbaan.com", "Bizbaan@2024");
            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Email == username);
            if (fndUsr is null)
            {
                return _rsp.MapError("Invalid Username or Password.");
            }
            if (OtpIsActive)
            {
                var otp = _otp.GenerateOtp();
                fndUsr.Otp = otp;
                fndUsr.WaitForOtp = true;
                fndUsr.OtpValidTo = DateTime.Now.AddMinutes(3);
                _dbObj.Update(fndUsr);
                await _ctx.SaveChangesAsync();
                var temp = _template.BindDataToTemplate("", ["USER", "OTP", "USERMAIL"], [fndUsr.Name + " " + fndUsr.Family, otp, fndUsr.Email]);
                _email.SendEmail("no-replay@bizbaan.com", fndUsr.Email, "Bizbaan - Verification code[limited]", temp);
                return _rsp.MapOk(msg: "Authentication code (OTP) hase been sent.please check your email inbox and spam.", additionalData: Guid.NewGuid().ToString());
            }
            return _rsp.MapError("Otp service unavailable.");
        }
        public async Task<ResponseObject> MakeSignin(HttpContext httpContext, string username, string? otp = null)
        {
            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Email == username);
            if (fndUsr is null)
            {
                return _rsp.MapError("Invalid Username or Password.");
            }
            if (fndUsr.WaitForOtp)
            {
                if (string.IsNullOrEmpty(otp))
                {
                    return _rsp.MapError("Authentication code (OTP) is required.");
                }
                if (!otp.Equals(fndUsr.Otp) || DateTime.Now > fndUsr.OtpValidTo)
                {
                    return _rsp.MapError("Invalid or Expired Authentication code (OTP).");
                }
                fndUsr.WaitForOtp = false;
                fndUsr.Otp = null;
                fndUsr.OtpValidTo = null;
                _dbObj.Update(fndUsr);
                await _ctx.SaveChangesAsync();
            }
            httpContext.Response.Cookies.Append("_BizToken_", fndUsr.AuthToken);
            httpContext.Request.Cookies.Append(new KeyValuePair<string, string>("_BizToken_", fndUsr.AuthToken));
            var role = _ctx.RolePermissions.Where(x => x.RoleId == fndUsr.RoleId).Include(x => x.Permission)/*.ThenInclude(x => x.Childs)*/.ToList();
            var permissions = role?.Select(x => x.Permission).OrderBy(x => x.Sort).ToList();
            var permdtos = PermissionToDto(permissions);
            AuthUserDto authUser = new()
            {

                Id = fndUsr.Id,
                UserName = $"{fndUsr.Name} {fndUsr.Family}",
                Email = fndUsr.Email,
                Token = fndUsr.AuthToken,
                RoleId = fndUsr.RoleId,
                Permissions = permdtos.Item1,
                PermissionUrls = permdtos.Item2
            };
            var jobject = JsonConvert.SerializeObject(authUser, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            httpContext.Session.Set("_BIZ_AUTH_USER_", Encoding.UTF8.GetBytes(jobject));
            httpContext.Request.Headers.Append("Authorization", $"Bearer {fndUsr.AuthToken}");
            httpContext.Response.Headers.Append("Authorization", $"Bearer {fndUsr.AuthToken}");
            return _rsp.MapOk(data: jobject);
        }
        public async Task<ResponseObject> ToggleDisable(int id)
        {
            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Id == id);
            if (fndUsr is null)
                return _rsp.MapOk("User not found.");

            fndUsr.IsDisabled = !fndUsr.IsDisabled;
            if (!fndUsr.IsDisabled)
                fndUsr.FailAccessCount = 0;

            _ctx.SaveChanges();
            return _rsp.MapOk();

        }
        public Tuple<List<PermissionDto>, List<string>> PermissionToDto(List<PermissionModel> input)
        {
            List<PermissionDto> PermDto = [];
            List<string> Urls = [];
            if (input != null && input.Count != 0)
            {
                foreach (var item in input.Where(x => x.ParentId is null).ToList())
                {
                    if (item.IsActive)
                    {
                        var pd = new PermissionDto
                        {
                            Sort = item.Sort,
                            Title = item.Title,
                            Url = item.Url
                        };
                        Urls.Add(item.Url);
                        if (item.Childs != null && item.Childs.Count != 0)
                        {
                            pd.Childs = [];
                            foreach (var child in item.Childs.ToList())
                            {
                                if (child.IsActive)
                                {
                                    Urls.Add(child.Url);
                                    pd.Childs.Add(new PermissionDto()
                                    {
                                        Sort = child.Sort,
                                        Title = child.Title,
                                        Url = child.Url
                                    });
                                }
                            }
                        }
                        PermDto.Add(pd);
                    }
                }
            }
            return new Tuple<List<PermissionDto>, List<string>>(PermDto, Urls);
        }
        public async Task<ResponseObject> ToggleBan(int id)
        {
            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Id == id);
            if (fndUsr is null)
                return _rsp.MapOk("User not found.");

            fndUsr.IsBanned = !fndUsr.IsBanned;
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }

        public async Task<ResponseObject> ResetPwd(ResetPwdDto rpd)
        {
            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Id == rpd.Id);
            if (fndUsr is null)
                return _rsp.MapOk("User not found.");
            if (!string.IsNullOrEmpty(rpd.OldPwd))
                if (!PasswordHelper.Verify(fndUsr, rpd.OldPwd))
                    return _rsp.MapError("رمز عبور قدیمی نادرست است");
            fndUsr.Password = rpd.NewPwd;
            fndUsr.Password = PasswordHelper.Hash(fndUsr);
            _ctx.SaveChanges();
            return _rsp.MapOk($"Password of {fndUsr.Name + " " + fndUsr.Family} updated successfully.");

        }
        public async Task<ResponseObject> ChangePwd(ResetPwdDto rpd)
        {
            if (string.IsNullOrEmpty(rpd.OldPwd))
                return _rsp.MapError("Old password is required.");

            var fndUsr = await _dbObj.FirstOrDefaultAsync(x => x.Id == rpd.Id);
            if (fndUsr is null)
                return _rsp.MapOk("User not found.");

            if (!PasswordHelper.Verify(fndUsr, rpd.OldPwd))
            {
                return _rsp.MapError("Invalid Creditional.");
            }

            fndUsr.Password = rpd.NewPwd;
            fndUsr.Password = PasswordHelper.Hash(fndUsr);
            _ctx.SaveChanges();
            return _rsp.MapOk($"Password of {fndUsr.Name + " " + fndUsr.Family} updated successfully.");

        }
    }
}
