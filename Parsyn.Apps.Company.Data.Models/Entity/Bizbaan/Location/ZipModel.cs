using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location
{
    public class ZipModel : BaseModel
    {
        public string? Zipcode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? State_Abbr { get; set; }
        public string? County_Area { get; set; }
        public string? Code { get; set; }
        public decimal Latitude { get; set; } = 0;
        public decimal Longitude { get; set; } = 0;
        public int? Some_Field { get; set; } = 0;
        public double? Distance { get; set; } = 0;
        public virtual ICollection<AdModel>? Ads { get; set; }
    }
}
