using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos
{
    public class LoginDto
    {
        [Required]
        public string Username {  get; set; }
        [Required]
        public string Password { get; set; }
        public string? Otp {  get; set; }
    }
}
