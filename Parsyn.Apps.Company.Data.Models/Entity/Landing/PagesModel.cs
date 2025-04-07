using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class PagesModel : BaseModel
    {
        public string? Title {  get; set; }
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public SeoModel? Seo { get; set; } = new SeoModel();
    }
}
