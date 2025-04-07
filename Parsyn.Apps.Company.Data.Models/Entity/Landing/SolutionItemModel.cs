using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class SolutionItemModel:BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url {  get; set; }
        public int? SolutionId {  get; set; }
        [ForeignKey(nameof(SolutionId))]
        public virtual SolutionModel? Solution { get; set; }
    }
}
