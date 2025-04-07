using Parsyn.Apps.Company.Data.Models.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.Catalog
{
    public class MediaDto:BaseDto
    {
        public string? OrginalFilePath { get; set; }
        public string? MediaFileType { get; set; } = "Photo";
        public string? JsonFileSize { get; set; }
        // FOR VIDEO FILES
        public string? Poster { get; set; }
        public string? AltText { get; set; }
        //SEO FRIENDLY NAMING FOR IMAGE FILES - USING IN GOOGLE ANALYTICS
        public string? Name { get; set; }
        public string? UrlInSitemap { get; set; }
        public string? MediaTitle { get; set; }
        public int CatId { get; set; } = 1;

    }
    public class JsonFileSize
    {
        public string? OrginalSize { get; set; }
        public string? AR169HW1600H900 { get; set; }
        public string? AR169HW1200H675 { get; set; }
        public string? AR11HW1200H1200 { get; set; }
        public string? AR43HW1200H900 { get; set; }
        public string? OGIMAGE { get; set; }
        public string? Thumbnail { get; set; }
    }
}
