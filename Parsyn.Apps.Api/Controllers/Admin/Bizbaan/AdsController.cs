using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using System.Text.Json.Serialization;

namespace Parsyn.Apps.Api.Controllers.Admin.Bizbaan
{
    [Route("/api/admin/[controller]")]
    [ApiController]

    public class AdsController(IAdIface srvc) : BizApiController
    {
        IAdIface _srvc = srvc;
        private RespGeneratorSrvc _rspgen = new();

        [HttpGet]
        [EndpointName("Ads GET ALL")]
        public ActionResult GetAll()
        {
            var result = _srvc.GetAllInclude().ToArray();
            return Content(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.GetInclude(Id);
            return new JsonResult(_rspgen.MapOk(data: opr),new System.Text.Json.JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve });
        }
        [HttpPost]
        public IActionResult Add(AdModel userDto)
        {
            AdModel um = userDto.Adapt<AdModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.Add(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(AdModel userDto)
        {
            AdModel um = userDto.Adapt<AdModel>();
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
