using Parsyn.Apps.Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class OtpGenerator:IOtpGenerator
    {
        public string GenerateOtp()
        {
            Random random = new();
            int otpNumber = random.Next(100000, 999999); // Generates a 6-digit number
            return otpNumber.ToString();
        }
    }
}
