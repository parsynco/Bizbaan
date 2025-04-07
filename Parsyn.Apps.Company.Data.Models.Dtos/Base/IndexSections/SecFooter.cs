using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.Base.IndexSections
{
    public class SecFooter
    {
        public List<FooterLinks>? Links { get; set; }
        public List<FooterSocial>? Socials { get; set; }
    }
    public class FooterLinks
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Url { get; set; }
    }
    public class FooterSocial
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }
}
