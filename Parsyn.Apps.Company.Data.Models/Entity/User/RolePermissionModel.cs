using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.User
{
    public class RolePermissionModel : BaseModel
    {
        public int? RoleId {  get; set; }
        public int? PermissionId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual RoleModel? Role { get; set; }
        [ForeignKey(nameof(PermissionId))]
        public virtual PermissionModel? Permission { get; set; }
    }
}
