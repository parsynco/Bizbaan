using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos
{
    public class ResetPwdDto
    {
        [Required]
        public int? Id { get; set; }

        public string? OldPwd {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? NewPwd {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPwd),ErrorMessage = "Password most match with confirm")]
        public string? Confirm {  get; set; }
    }
}
