using Parsyn.Apps.Company.Data.Models.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos
{
    public class UserDto:BaseDto
    {
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }
        [MaxLength(40)]
        public string? Family { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        [MaxLength(80)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [NotMapped]
        public string?  ConfirmPassword { get; set; }
        public bool ForceChangePassword { get; set; } = true;
        public int RoleId { get; set; } = 0;
        public string RoleTitle { get; set; } = "";
        public bool IsDisabled { get; set; } = false;
        public bool IsBanned { get; set; } = false;
        
    }
}
