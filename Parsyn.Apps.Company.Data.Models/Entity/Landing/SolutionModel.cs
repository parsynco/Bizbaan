using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class SolutionModel : BaseModel
    {
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public SeoModel? Seo { get; set; } = new SeoModel();
        public virtual List<SolutionItemModel>? Items {  get; set; }
    }
}
