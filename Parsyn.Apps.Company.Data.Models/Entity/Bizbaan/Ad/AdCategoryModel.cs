using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad
{
    public class AdCategoryModel : BaseModel
    {
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public SeoModel? Seo { get; set; } = new SeoModel();
        public int? ParentId { get; set; } 
        [ForeignKey(nameof(ParentId))]
        public AdCategoryModel? Parent { get; set; }
        public virtual ICollection<AdModel>? Ads { get; set; }
        public virtual ICollection<AdCategoryModel>? Childs { get; set; }
       
    }
}
