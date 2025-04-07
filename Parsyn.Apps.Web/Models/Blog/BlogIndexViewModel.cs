using Parsyn.Apps.Company.Data.Models.Entity.Landing;

namespace Parsyn.Apps.Web.Models.Blog
{
    public class BlogIndexViewModel
    {
        public List<ArticleModel>? BreakingNews { get; set; }
        public List<ArticleModel>? Articles { get; set; }
        public List<ArticleCategoryModel>? ArticlesCategories { get; set; }
        public int SelectedCategory { get; set; } = 0;

    }
}
