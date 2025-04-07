using K4os.Compression.LZ4.Streams.Frames;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Helpers
{
    public static class FileMgrHelper
    {
        public static Tuple<Stream, FileInfo> ReadFile(string path)
        {
            return FileNotFound(path);
        }
        public static Tuple<Stream, FileInfo> ReadFile(string path,string jsonFileSize,string size = "THUMB")
        {
            JsonFileSize jfs = JsonConvert.DeserializeObject<JsonFileSize>(jsonFileSize);
            var fileBySize = size switch
            {
                "THUMB"=>jfs?.Thumbnail,
                "OG"=>jfs?.OGIMAGE,
                "OS"=>jfs?.OrginalSize,
                "AR169BIG"=>jfs?.AR169HW1600H900,
                "AR169SMALL"=>jfs?.AR169HW1200H675,
                "AR11"=>jfs?.AR11HW1200H1200,
                "AR43"=>jfs?.AR43HW1200H900,
                _ => "noimage.jpg"
            };
            var filePath = Path.Combine(path, "Media", "FileManager", "Images", fileBySize);
            var defaultOriginalSizePath = Path.Combine(path, "Media", "FileManager", "Images", jfs?.OrginalSize);
            FileInfo finfo ;
            byte[] farray;
            try
            {
                finfo =  new FileInfo(filePath);
                farray = File.ReadAllBytes(filePath);
                 
            }
            catch
            {
                finfo = new FileInfo(defaultOriginalSizePath);
                farray = File.ReadAllBytes(defaultOriginalSizePath);
            }
            var stream = new MemoryStream(farray);
            return new Tuple<Stream, FileInfo>(stream, finfo);
        }
        public static Tuple<Stream,FileInfo> FileNotFound(string path)
        {
            var filePath = Path.Combine(path, "Media", "FileManager", "Images", "noimage.jpg");
            var finfo = new FileInfo(filePath);
            var farray =  File.ReadAllBytes(filePath);
            var stream = new MemoryStream(farray);
            return new Tuple<Stream, FileInfo>(stream,finfo);
        }
    }
}
