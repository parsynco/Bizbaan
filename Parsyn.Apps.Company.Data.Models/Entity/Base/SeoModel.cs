using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Base
{
    public class SeoModel:BaseModel
    {
        public string? Title {  get; set; }
        public string? Url {  get; set; }
        public string? Description {  get; set; }
        public string? Keywords {  get; set; }
        public string? Image {  get; set; }
        public int EntityId {  get; set; }
    }
}
