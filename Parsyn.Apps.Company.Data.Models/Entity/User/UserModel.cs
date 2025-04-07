using Microsoft.AspNetCore.Identity;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.User
{
    public class UserModel:BaseModel
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
        public int FailAccessCount { get; set; } = 0;
        public bool IsBanned { get; set; } = false;
        public bool IsDisabled { get; set; } = false;
        public bool WaitForOtp { get; set; } = false;
        public string? Otp { get; set; }
        public DateTime? OtpValidTo {  get; set; } = DateTime.Now.AddMinutes(3);
        public string? PrivateKey {  get; set; }
        [NotMapped]
        public string?  ConfirmPassword { get; set; }
        public bool ForceChangePassword { get; set; } = true;
        public int? RoleId {  get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual RoleModel? Role { get; set; }
        public string? AuthToken { get; set; }
        public UserModel Copy()
        {
            return (UserModel)this.MemberwiseClone();
        }
        public UserDto Dto(bool hidePwd = true)
        {
            var obj = Copy();
            return new UserDto()
            {
               Id = this.Id,
               Name = this.Name,
               Family = this.Family,
               Phone = this.Phone,
               Email = this.Email,
               Created_At = this.Created_At,
               Password = (hidePwd) ? null: this.Password,
               ForceChangePassword = this.ForceChangePassword,
               RoleId = (int)this.RoleId,
               RoleTitle = this.Role.Title,
               IsBanned = this.IsBanned,
               IsDisabled = this.IsDisabled,
            };
        }
      
    }
}
