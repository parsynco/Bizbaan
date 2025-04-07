using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Reactions
{
    public class SubscribeModel : BaseModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? IP { get; set; }
    }
}
