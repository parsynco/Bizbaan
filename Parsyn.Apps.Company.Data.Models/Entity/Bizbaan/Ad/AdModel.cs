using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad
{
    public class AdModel : BaseModel
    {
        public int CategoryId {  get; set; }
        [ForeignKey(nameof(CategoryId))]
        public AdCategoryModel? Category { get; set; }
        public int ZipId {  get; set; }
        [ForeignKey(nameof(ZipId))]
        public virtual ZipModel? Zip { get; set; }
        public virtual ICollection<AdImageModel>? Images { get; set; }
        public SeoModel? Seo { get; set; } = new SeoModel();
        /***********/
        public string? RegionName { get { return Zip?.County_Area; }  }
        public string? CityName { get { return Zip?.City; }  }
        public string? ProivinceName { get { return Zip?.State; } }
        public string? ProvinceAbbr { get { return Zip?.State_Abbr; } }
        /***********/
        public bool IsSpecial { get; set; } = false;
        public string? Title { get; set; }
        public string? TitleEn { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Telephone { get; set; }
        public string? ZipCode { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Lat { get; set; }
        public string? Lng { get; set; }
        public string? EmbedMapAddress { get; set; }
       

    }
}
