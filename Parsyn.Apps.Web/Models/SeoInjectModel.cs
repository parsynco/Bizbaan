using Parsyn.Apps.Company.Data.Models.Entity.Base;

namespace Parsyn.Apps.Web.Models
{
    public class SeoInjectModel
    {
        public int? SeoId { get; set; } = 0;
        public SeoModel? Seo { get; set; } = null;
    }
}
