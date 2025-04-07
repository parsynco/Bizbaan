using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class FaqModel : BaseModel
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Image { get; set; }
        public int FaqCatId { get; set; }
        [ForeignKey(nameof(FaqCatId))]
        public FaqCatModel? FaqCat { get; set; }
    }
}
