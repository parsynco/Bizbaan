using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Reactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class ArticleModel:BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public SeoModel? Seo { get; set; } = new SeoModel();

        public int CategoryId {  get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ArticleCategoryModel? ArticleCategory { get; set; }
        public ICollection<VisitModel>? Visits { get; set; }
        public ICollection<CommentModel>? Comments { get; set; }
        public ICollection<LikeModel>? Likes { get; set; }
    }
}
