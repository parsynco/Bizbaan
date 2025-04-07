using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Parsyn.Apps.Company.Data.Models.Entity.User;
namespace Parsyn.Apps.Company.Service.Utiles.Helpers
{
    public static  class PasswordHelper
    {
        public static string Hash(this UserModel user)
        {
            string _Salt  = BCrypt.Net.BCrypt.GenerateSalt();
            user.PrivateKey = _Salt;
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password,salt:_Salt,false,hashType:HashType.SHA512);
            return hashed;
        }
        public static bool Verify(this UserModel user,string Password)
        {
            string _Salt  = user.PrivateKey;
            
            try
            {
                var hashed = BCrypt.Net.BCrypt.Verify(Password, user.Password, false, hashType: HashType.SHA512);
                return hashed;
            }
            catch(Exception ex)
            {
                return false;
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
