using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Dtos.Catalog;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Config
{
    public class MediaModel:BaseModel
    {
        public string? OrginalFilePath { get; set; }
        public string? MediaFileType { get; set; }
        public string? JsonFileSize { get; set; }
        // FOR VIDEO FILES
        public string? Poster { get; set; }
        public string? AltText { get; set; }
        //SEO FRIENDLY NAMING FOR IMAGE FILES - USING IN GOOGLE ANALYTICS
        public string? Name { get; set; }
        public string? UrlInSitemap { get; set; }
        public string? MediaTitle { get;set; }
        public int? CatId {  get; set; }
        [ForeignKey(nameof(CatId))]
        public MediaCatModel? Category { get; set; }
        public MediaModel Copy()
        {
            return (MediaModel)this.MemberwiseClone();
        }
        public MediaDto Dto()
        {
            var obj = Copy();
            return new MediaDto()
            {
                Id = this.Id,
                Name = this.Name,
                AltText = this.AltText,
                JsonFileSize = this.JsonFileSize,
                MediaFileType = this.MediaFileType,
                MediaTitle = this.MediaTitle,
                Created_At = this.Created_At,
                OrginalFilePath = this.OrginalFilePath,
                Poster = this.Poster,
                UrlInSitemap = this.UrlInSitemap
            };
        }
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
