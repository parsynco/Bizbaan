using Parsyn.Apps.Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class TemplateEngine : ITemplateEngine
    {
        public string BindDataToTemplate(string templatePath, string[] placeholder, string[] data)
        {
            if (!File.Exists(templatePath))
            {
                templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"templates","email","index.html");
            }

            string templateContent = File.ReadAllText(templatePath);
            for(int i =0;i< placeholder.Length;i++)
            {
                templateContent = templateContent.Replace("{{"+placeholder[i]+"}}", data[i]);
            }
            return templateContent;
        }
    }
}
