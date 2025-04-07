using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IEmailService
    {
        void Config(string smtpServer, int smtpPort, string username, string password);
        void SendEmail(string from, string to, string subject, string body);
    }
}
