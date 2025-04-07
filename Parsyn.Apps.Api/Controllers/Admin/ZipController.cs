using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;

namespace Parsyn.Apps.Api.Controllers.Admin
{
    [Route("/api/admin/[controller]")]
    [ApiController]
    public class ZipController(IZipIface srvc) : BizApiController
    {
        IZipIface _srvc = srvc;
        private RespGeneratorSrvc _rspgen = new();

        [HttpGet]
        [EndpointName("ZIPCODE GET ALL")]
        public ActionResult GetAll(int page = 1, string? q = null)
        
        {
            if(q != null && q.Length == 5)
            {
                Console.Write("Hallo");
            }
            var result =string.IsNullOrEmpty(q) ? _srvc.GetLightPaged(page) : _srvc.GetLightPaged(page,q).ToList();
            return Content(JsonConvert.SerializeObject(result));
        }
        [HttpGet]
        [Route("paged/{page}")]
        [EndpointName("ZIPCODE GET ALL FILTERED")]
        public async Task<ActionResult> Paged(int page = 1)
        
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject((await _srvc.GetAllAsync(page,100)).Data);
            return Content(result);
        }
        [HttpGet]
        [Route("pages")]
        [EndpointName("ZIPCODE GET PAGE COUNT")]
        public async Task<ActionResult> Pages()
        
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(_srvc.GetPageCount());
            return Content(result);
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.Get(x => x.Id == Id);
            return new JsonResult(opr);
        }
        [HttpPost]
        public IActionResult Add(ZipModel userDto)
        {
            ZipModel um = userDto.Adapt<ZipModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.Add(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(ZipModel userDto)
        {
            ZipModel um = userDto.Adapt<ZipModel>();
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
