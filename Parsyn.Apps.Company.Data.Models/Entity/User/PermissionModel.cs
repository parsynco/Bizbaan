using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.User
{
    public class PermissionModel : BaseModel
    {
        public int? Sort { get; set; } = 0;
        public int? Code { get; set; }
        public string? Title {  get; set; }
        public string? Url { get; set; }
        public virtual ICollection<RolePermissionModel>? Roles { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual PermissionModel? Parent { get; set; }
        public virtual ICollection<PermissionModel>? Childs { get; set; }
        
    }
}
