using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services;

namespace Parsyn.Apps.Api.Controllers.Admin
{
    [Route("/api/admin/[controller]")]
    [ApiController]
    
    public class UserController : BizApiController
    {
        IUserIface _userSrvc;
        private RespGeneratorSrvc _rspgen; 
        public UserController(IUserIface srvc)
        {
            _userSrvc = srvc;
            _rspgen = new RespGeneratorSrvc();
        }
        [HttpGet]
        [EndpointName("ADMIN USER GETALL")]
        public ActionResult GetAll()
        {
            var result = (_userSrvc.GetAllInclude().Select(x => x.Dto()).ToArray());
            return Content(JsonConvert.SerializeObject(result));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _userSrvc.Get(x => x.Id == Id);
            return new JsonResult(opr);
        }
        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {
           try
            {
                UserModel um = userDto.Adapt<UserModel>();
                um.Created_At = DateTime.Now;
                var opr = _userSrvc.Add(um);
                return new JsonResult(opr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost("ResetPwd")]
        public async Task<IActionResult> ResetPwd(ResetPwdDto rpd)
        {
            if (!ModelState.IsValid)
                return new JsonResult(_rspgen.MapError("Invalid request.",data: ModelState.Values.SelectMany(v => v.Errors).ToList()));
            var opr = await _userSrvc.ResetPwd(rpd);
            return new JsonResult(opr);
        }
        [HttpPost("Disable")]
        public async Task<IActionResult> Disable(int id)
        {
           
            var opr = await _userSrvc.ToggleDisable(id);
            return new JsonResult(opr);
        }
        [HttpPost("Bann")]
        public async Task<IActionResult> Bann(int id)
        {
           
            var opr = await _userSrvc.ToggleBan(id);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(UserDto userDto)
        {
            UserModel um = userDto.Adapt<UserModel>();
            if(!_userSrvc.ExistsById(x => x.Id == um.Id))
            {
                return new JsonResult(_rspgen.MapError("کاربر مورد نظر یافت نشد"));
            }
            var opr = _userSrvc.Update(um);
            return new JsonResult(opr);
        }
        [HttpPost("Delete")]
        public ActionResult Delete(int Id)
        {
            var opr = _userSrvc.Delete(x => x.Id == Id);
            return new JsonResult(opr);
        }
    }
}
