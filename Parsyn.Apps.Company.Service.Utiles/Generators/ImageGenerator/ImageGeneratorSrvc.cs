using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using Parsyn.Apps.Company.Service.Utiles.Enums;
using System.Drawing;
using LazZiya.ImageResize;
using EasyCompressor;
using Parsyn.Apps.Company.Data.Models.Entity.Config;
namespace Parsyn.Apps.Company.Service.Utiles.Generators.ImageGenerator
{
    public class ImageGeneratorSrvc
    {
        private readonly ICompressor _compressor =  new LZ4Compressor();
        private readonly List<SEOImageSize> _imageSizes = [new SEOImageSize() { Width = 1600,Height=900 }, new SEOImageSize() { Width = 1200, Height = 675 }, new SEOImageSize() { Width = 1200, Height = 1200 }, new SEOImageSize() { Width = 1200, Height = 900 }, new SEOImageSize() { Width = 1200, Height = 630 }, new SEOImageSize() { Width = 200, Height = 200 }]; 
        public JsonFileSize ResizeToSEOFriendly(byte[] data, string format, string rootPath,bool saveResize = true)
        {
            JsonFileSize Result = new JsonFileSize();
            string mainFileName = "";
            using (var stream = new MemoryStream(data))
            {
                var mainFileStr = Guid.NewGuid().ToString();
                mainFileName = Path.Combine(rootPath, mainFileStr + ValidMimeTypes.MimeToExt(format));
                
                Result.OrginalSize = mainFileStr + ValidMimeTypes.MimeToExt(format);
                using (var fstream = new FileStream(mainFileName, FileMode.CreateNew, FileAccess.Write))
                {
                    stream.CopyTo(fstream);
                }
               if(saveResize)
                {
                    using (var img = Image.FromStream(stream))
                    {
                        var iOps = new ImageWatermarkOptions
                        {
                            Opacity = 50,
                            Location = TargetSpot.BottomLeft

                        };
                        foreach (var size in _imageSizes)
                        {
                            var fileName = mainFileStr + size.WH + ValidMimeTypes.MimeToExt(format);
                            var fn = Path.Combine(rootPath, fileName);
                            img.Scale(size.Width, size.Height)
                           .SaveAs(fn);
                            if (size.WH == "1600x900")
                                Result.AR169HW1600H900 = fileName;
                            if (size.WH == "1200x900")
                                Result.AR43HW1200H900 = fileName;
                            if (size.WH == "1200x1200")
                                Result.AR11HW1200H1200 = fileName;
                            if (size.WH == "1200x675")
                                Result.AR169HW1200H675 = fileName;
                            if (size.WH == "1200x630")
                                Result.OGIMAGE = fileName;
                            if (size.WH == "200x200")
                                Result.Thumbnail = fileName;
                        }

                    }
                }
            }
            return Result;
        }


    }
    public class SEOImageSize()
    { 
        public int Width { get; set; }
        public int Height { get; set; }
        public string WH => $"{Width}x{Height}";
    }

}
