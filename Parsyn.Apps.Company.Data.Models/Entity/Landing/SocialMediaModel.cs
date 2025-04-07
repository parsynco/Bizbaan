using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class SocialMediaModel:BaseModel
    {
        public string? Title {  get; set; }
        public string? Icon {  get; set; }
        public string? Url {  get; set; }

    }
}
