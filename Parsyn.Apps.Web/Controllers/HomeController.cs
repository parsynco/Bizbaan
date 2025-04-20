using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos.Base.IndexSections;
using Parsyn.Apps.Company.Data.Models.Entity.Forms;
using Parsyn.Apps.Company.Data.Models.Entity.Reactions;
using Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Services;
using Parsyn.Apps.Web.Models;
using Parsyn.Apps.Web.Models.Bizban;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Parsyn.Apps.Web.Controllers
{
    [ResponseCache(Duration = 43200, Location = ResponseCacheLocation.Client)]
    [OutputCache(Duration = 43200)]
    public class HomeController(ILogger<HomeController> logger, IFormsIface forms, IAdIface adsIface, IArticleIface articleIface, IZipIface ziprad, ISubscribeIface subscribeIface, IOptionIface optionIface) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IFormsIface _forms = forms;
        private readonly IArticleIface _articleIface = articleIface;
        private readonly IAdIface _adsIface = adsIface;
        private readonly IZipIface _ziprad = ziprad;
        private readonly ISubscribeIface _subscribeIface = subscribeIface;
        private readonly IOptionIface _optionSrvc = optionIface;

        public async Task<IActionResult> Index()
        {
            var result = new IndexSectionModel
            {
                Sec2 = await _optionSrvc.GetAsModel<Sec2Dto>("S2"),
                Sec4 = await _optionSrvc.GetAsModel<Sec4Dto>("S4"),
                Sec5 = await _optionSrvc.GetAsModel<Sec5Dto>("S5")
            };
            return View(result);
        }
        [Route("/{url}")]
        public async Task<IActionResult> Index(string url)
        {
            var item = _adsIface.GetInclude(url);
            if (item is null)
            {
                var result = new IndexSectionModel
                {
                    Sec2 = await _optionSrvc.GetAsModel<Sec2Dto>("S2"),
                    Sec4 = await _optionSrvc.GetAsModel<Sec4Dto>("S4"),
                    Sec5 = await _optionSrvc.GetAsModel<Sec5Dto>("S5")
                };
                return View(result);
            }

            return View("Ads", item);
        }
        [HttpGet]
        [Route("/ads")]
        public async Task<IActionResult> Ads(int adid, string title)
        {
            var item = _adsIface.GetInclude(adid);
            return View(item);
        }

        [HttpPost("/Search")]
        public async Task<IActionResult> Search([FromBody] SearchModel model)
        {
            var data = await _adsIface.Search((int)model.CatId, model.Title, model.Region);
            return Json(new { status = true, data = JsonConvert.SerializeObject(data, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }) });
        }

        [HttpPost("/Subscribe")]
        public async Task<IActionResult> Search([FromBody] SubscribeModel email)
        {
            if (!ModelState.IsValid)
                return Json(new { status = 1, msg = "Invalid email format." });

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            email.IP = ip;
            var data = await _subscribeIface.Subscribe(email.Email);
            return Json(data);
        }

        [HttpGet("/about")]

        public IActionResult About()
        {
            return View();
        }
        /**************************************************************/
        [HttpGet("/contactus")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost("/about")]
        public IActionResult Contact([FromForm] FormModel fm)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            fm.IP = ip;
            var res = _forms.Add(fm);
            ViewData["Response"] = res.Msg;
            return RedirectToAction("about");
        }

        /**************************************************************/

        /***************************************************************/

        /*****************************************************************/
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
