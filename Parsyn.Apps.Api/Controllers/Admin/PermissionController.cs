using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;

namespace Parsyn.Apps.Api.Controllers.Admin
{
    [Route("/api/admin/[controller]")]
    [ApiController]
    
    public class PermissionController(IPermissionIface srvc) : BizApiController
    {
        IPermissionIface _srvc = srvc;
        private RespGeneratorSrvc _rspgen = new RespGeneratorSrvc();

        [HttpGet]
        [EndpointName("PERMISSIONS GET ALL")]
        public ActionResult GetAll()
        {
            var result = _srvc.GetAll().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpGet]
        [EndpointName("PERMISSIONS GET NO PARENTS")]
        [Route("GetLevelOne")]
        public ActionResult GetLevelOne()
        {
            var result = _srvc.GetLevelOne().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpGet]
        [EndpointName("PERMISSIONS GET TREE VIEW")]
        [Route("GetTreeView")]
        public ActionResult GetTreeview()
        {
            var result = _srvc.TreeViewFriendly().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.GetById(Id);
            return new JsonResult(_rspgen.MapOk(data: opr));
        }
        [HttpPost]
        public IActionResult Add(PermissionModel userDto)
        {
            PermissionModel um = userDto.Adapt<PermissionModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.Add(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(PermissionModel userDto)
        {
            PermissionModel um = userDto.Adapt<PermissionModel>();
            if(!_srvc.ExistsById(x => x.Id == um.Id))
            {
                return new JsonResult(_rspgen.MapError("رکورد مورد نظر یافت نشد"));
            }
            var opr = _srvc.Update(um);
            return new JsonResult(opr);
        }
        [HttpPost("Delete")]
        public ActionResult Delete(int Id)
        {
            var opr = _srvc.Delete(x => x.Id == Id);
            return new JsonResult(opr);
        }
    }
}
