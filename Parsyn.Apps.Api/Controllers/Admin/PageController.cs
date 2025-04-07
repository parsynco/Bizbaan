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
    
    public class PageController(IPageIface srvc) : BizApiController
    {
        IPageIface _srvc = srvc;
        private RespGeneratorSrvc _rspgen = new();

        [HttpGet]
        [EndpointName("PAGES GET ALL")]
        public ActionResult GetAll()
        {
            var result = _srvc.IncludeDependencies().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.Get(x => x.Id == Id);
            return new JsonResult(opr);
        }
        [HttpGet("GetByName")]
        public ActionResult GetByName(string name)
        {
            var opr = _srvc.IncludeDependencies().FirstOrDefault(x => x.Name == name);
            return new JsonResult(opr);
        }
        [HttpPost]
        public IActionResult Add(PagesModel userDto)
        {
            PagesModel um = userDto.Adapt<PagesModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.AddOrUpdate(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(PagesModel userDto)
        {
            PagesModel um = userDto.Adapt<PagesModel>();
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
