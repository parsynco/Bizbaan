using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Helpers
{
    public class UrlHelper
    {
        public  string ApiUrl()
        {
            //_readFile();
            var url = "https://api.bizbaan.com/api/admin/";
            //var url = "http://localhost:5021/api/admin/";

            return url;
        }

    }
}
