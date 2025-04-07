using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos
{
    public class ChangePwdDto
    {
        public string? OldPassword {  get; set; }
        [Required]
        public  string NewPassword { get; set; }
        [Compare(nameof(NewPassword),ErrorMessage ="رمز عبور جدید با تکرار آن مطابقت ندارد")]
        public  string Confirm { get; set; }
    }
}
