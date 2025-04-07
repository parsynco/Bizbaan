using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
namespace Parsyn.Apps.Company.Service.Utiles.Enums
{
    public static class ValidMimeTypes
    {
       public static List<string> ValidTypes()
        {
            return new List<string>
            {
                MediaTypeNames.Image.Webp,
                MediaTypeNames.Image.Jpeg,
                MediaTypeNames.Image.Png,
                MediaTypeNames.Image.Svg
            };
       
        }

        public static string MimeToExt(string mime)
        {
            var valids = ValidTypes();
            if (!valids.Any(x => x == mime))
                throw new Exception("Invalid image format.");

            return mime switch
            {
                MediaTypeNames.Image.Webp => ".webp",
                MediaTypeNames.Image.Jpeg => ".jpg",
                MediaTypeNames.Image.Png => ".png",
                MediaTypeNames.Image.Svg => ".svg",
                _ => throw new Exception("Invalid image format.")
            };

        }
        public  enum UIMediaType
        {
            Video = 0,
            Photo = 1
        }
    }
}
