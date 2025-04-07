using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad
{
    public class AdImageModel : BaseModel
    {
        public int? MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public MediaModel? Media { get; set; }
        public int? AdId { get; set; }
        [ForeignKey(nameof(AdId))]
        public AdModel? Ad { get; set; }
    }
}
