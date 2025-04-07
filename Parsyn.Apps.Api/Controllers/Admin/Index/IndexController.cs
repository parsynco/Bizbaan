using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parsyn.Apps.Api.Core.Base;
using Parsyn.Apps.Company.Data.Models.Dtos.Base.IndexSections;
using Parsyn.Apps.Company.Data.Models.Entity;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;

namespace Parsyn.Apps.Api.Controllers.Admin.Index
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class IndexController : BizApiController
    {
        private readonly ISeoIface _seoIface;
        private readonly IOptionIface _optIface;
        public IndexController(ISeoIface seoIface,IOptionIface optIface)
        {
            _seoIface = seoIface;
            _optIface = optIface;
        }
        [HttpPost("GetSec2")]
        public async Task<ActionResult> GetOptionSec2(string Key)
        {
            var opr =await _optIface.GetAs<Sec2Dto>(Key);
            return new JsonResult(opr);
        }
        [HttpPost("GetSec4")]
        public async Task<ActionResult> GetOptionSec4(string Key)
        {
            var opr = await _optIface.GetAs<Sec4Dto>(Key);
            return new JsonResult(opr);
        }
        [HttpPost("GetSec5")]
        public async Task<ActionResult> GetOptionSec5(string Key)
        {
            var opr = await _optIface.GetAs<Sec5Dto>(Key);
            return new JsonResult(opr);
        }
        [HttpPost("GetFooterLinks")]
        public async Task<ActionResult> GetOptionFooterLink(string Key)
        {
            var opr = await _optIface.GetAs<List<FooterLinks>>(Key);
            return new JsonResult(opr);
        }
        [HttpPost("GetSocials")]
        public async Task<ActionResult> GetOptionSocials(string Key)
        {
            var opr = await _optIface.GetAs<List<FooterSocial>>(Key);
            return new JsonResult(opr);
        }
        [HttpPost]
        [Route("UpdateOption")]
        public async Task<ActionResult> UpdateOption(OptionsModel model)
        {
            return new JsonResult(_optIface.AddOrUpdate(model));
        }
        [HttpPost]
        public async Task<ActionResult> UpdateSeo(SeoModel seo)
        {
            return new JsonResult(_seoIface.AddOrUpdate(seo));
        }
        [HttpPost("GetByEntityId")]
        public async Task<ActionResult> GetSeo(SeoModel seo)
        {
            var data = _seoIface.Get(x => x.EntityId == seo.EntityId);
            return new JsonResult(data);
        }
    }
}
