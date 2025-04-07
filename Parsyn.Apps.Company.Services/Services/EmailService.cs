using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Parsyn.Apps.Company.Services.Interfaces;

namespace Parsyn.Apps.Company.Services.Services
{
    public class EmailService() : IEmailService
    {
        private string _smtpServer { get; set; }
        private int _smtpPort { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }
        public void Config(string smtpServer, int smtpPort, string username, string password)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _username = username;
            _password = password;
        }
        public void SendEmail(string from, string to, string subject, string body)
        {

            try
            {
                using (SmtpClient client = new(_smtpServer, _smtpPort))
                {
                    //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = false; // Enable SSL for secure communication
                    client.Credentials = new NetworkCredential(_username, _password);

                    MailMessage mailMessage = new(from, to, subject, body)
                    {
                        IsBodyHtml = true // Set the email body as HTML
                    };

                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
