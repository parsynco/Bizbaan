using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class IndexCirclesModels : BaseModel
    {
        public string? Url {  get; set; }
        public string? Content { get; set; }
        public SeoModel? Seo { get; set; }
    }
}
