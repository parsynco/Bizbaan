using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Dtos;
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

    public class ArticleController : BizApiController
    {
        IArticleIface _srvc;
        private RespGeneratorSrvc _rspgen;
        public ArticleController(IArticleIface srvc)
        {
            _srvc = srvc;
            _rspgen = new RespGeneratorSrvc();
        }
        [HttpGet]
        [EndpointName("ARTICLE  GET ALL")]
        public ActionResult GetAll()
        {
            var result = ((List<ArticleModel>)_srvc.GetAll(0, 0).Data).ToArray();
            return Content(JsonConvert.SerializeObject(result));
        }
        [HttpPost("GetById")]
        public ActionResult GetById(int Id)
        {
            var opr = _srvc.Get(x => x.Id == Id);
            return new JsonResult(opr);
        }
        [HttpPost]
        public IActionResult Add(ArticleModel userDto)
        {
            ArticleModel um = userDto.Adapt<ArticleModel>();
            um.Created_At = DateTime.Now;
            var opr = _srvc.Add(um);
            return new JsonResult(opr);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(ArticleModel userDto)
        {
            ArticleModel um = userDto.Adapt<ArticleModel>();
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
