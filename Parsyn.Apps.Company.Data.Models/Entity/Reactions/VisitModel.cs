using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Reactions
{
    public class VisitModel : BaseModel
    {
        public string? IP {  get; set; }
        public int EntityId {  get; set; }

    }
}
