using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Helpers
{
    public static class StringHelper
    {
        public static string ToggleName(this string name)
        {
            if (name.EndsWith("Dto"))
            {
                return name.Replace("Dto","Model");
            }
            else if (name.EndsWith("Model"))
            {
                return name.Replace("Model", "Dto");
            }
            return name;
        }
    }
}
