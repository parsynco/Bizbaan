using BreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Web.Models.Blog;
using System.ComponentModel;

namespace Parsyn.Apps.Web.Controllers
{
    [BreadCrumb(UseDefaultRouteUrl = true, Order = 0)]
    [DisplayName("اخبار و مقالات")]
    public class BlogController(IArticleCatIface articleCatIface, IArticleIface articleIface) : Controller
    {
        private readonly IArticleCatIface _articleCatIface = articleCatIface;
        private readonly IArticleIface _articleIface = articleIface;
        [BreadCrumb(Order = 1,Title ="دسته ها")]
        [Description("دسته های خبر")]
        [Route("/blog/breaking-news")]
        public async Task<IActionResult> Index(string? title = null, int? cat = 0, int? pg = 1, string? q = null)
        {
            var randomArticles = cat == 0 ? await _articleIface.RandomListPaged(pg ?? 0,q) : await _articleIface.RandomListPaged(cat: (int)cat, pg ?? 0,q);
            var categories = await _articleCatIface.GetAllIncludeSeoAsync();
            return View(new BlogIndexViewModel()
            {
                BreakingNews = await _articleIface.RandomListPaged(pg ?? 0),
                Articles = randomArticles,
                ArticlesCategories = categories,
                SelectedCategory = (int)cat
            });
        }
        [BreadCrumb(Order = 2)]
        [Description("جزئیات خبر")]
        [Route("/blog/news/{id:int}/{title?}")]
        public async Task<IActionResult> News(int id, string? title = null)
        {
            var article = _articleIface.GetById(id);
            return View(article);
        }
    }
}
