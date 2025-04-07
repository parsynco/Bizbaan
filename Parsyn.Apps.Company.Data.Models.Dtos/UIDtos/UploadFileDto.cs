using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.UIDtos
{
    public class UploadFileDto
    {
        public byte[] Content { get; set; }
        public string FileType {  get; set; }
        public string FileName { get; set; }
        public bool IsImage { get; set; }
        public bool AutoResize { get; set; }
    }
}
