using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;

namespace Parsyn.Apps.Api.Controllers.Admin.Bizbaan
{
    [Route("/api/admin/[controller]")]
    [ApiController]

    public class AdCategoryController : BizApiController
    {
        IAdCategoryIface _srvc;
        private RespGeneratorSrvc _rspgen;
        public AdCategoryController(IAdCategoryIface srvc)
        {
            _srvc = srvc;
            _rspgen = new RespGeneratorSrvc();
        }
        [HttpGet]
        [EndpointName("Category GET ALL")]
        public ActionResult GetAll()
        {
            var result = _srvc.GetAllInclude().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpGet("l2")]
        [EndpointName("Category GET ALL L2")]
        public ActionResult GetAllL2()
        {
            var result = _srvc.GetLevelTwo().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpGet("l1")]
        [EndpointName("Category GET ALL L1")]
        public ActionResult GetAllL1()
        {
            var result = _srvc.GetLevelOne().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.GetInclude(Id);
            return new JsonResult(_rspgen.MapOk(data: opr));
        }
        [HttpPost]
        public IActionResult Add(AdCategoryModel userDto)
        {
            AdCategoryModel um = userDto.Adapt<AdCategoryModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.Add(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(AdCategoryModel userDto)
        {
            AdCategoryModel um = userDto.Adapt<AdCategoryModel>();
            if (!_srvc.ExistsById(x => x.Id == um.Id))
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
