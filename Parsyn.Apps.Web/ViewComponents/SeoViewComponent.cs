using Microsoft.AspNetCore.Mvc;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services;
using Parsyn.Apps.Web.Models;
using System.Security.Cryptography;

namespace Parsyn.Apps.Web.ViewComponents
{
    public class SeoViewComponent(ISeoIface seoIface) : ViewComponent
    {
        private readonly ISeoIface _seoIface = seoIface;

        public async Task<IViewComponentResult> InvokeAsync(SeoInjectModel model)
        {
            SeoModel mdl = new SeoModel();
            if (model.SeoId != null && model.SeoId != 0)
            {
                mdl = _seoIface.Get((int)model.SeoId);
            }
            if (model.Seo != null)
            {
                mdl = model.Seo;
            }

            return View(mdl);
        }
    }
}
