using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos
{
    public class AuthUserDto
    {
        public int? Sort { get; set; } = 0;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? RoleId {  get; set; }
        public string Token {  get; set; }
        public List<PermissionDto>? Permissions { get; set; }
        public List<string>? PermissionUrls { get; set; }
    }
 
}
