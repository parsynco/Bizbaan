using Parsyn.Apps.Company.Data.Models.Entity.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Base
{
    public class CustomerModel : BaseModel
    {
        public int MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public MediaModel? Image { get; set; }
        public string? Comment {  get; set; }
        public int Rate { get; set; } = 0;
        public string? ConsentLetter {  get; set; }
    }
}
