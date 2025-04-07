using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Parsyn.Apps.Company.Data.Models.Entity.User
{
    public class RoleModel : BaseModel
    {
        
        public string? Title {  get; set; }
        public virtual ICollection<RolePermissionModel>? Permissions { get; set; }
        public virtual ICollection<UserModel>? Users { get; set; }
    }
}
