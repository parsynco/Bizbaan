using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces.Bizbaan
{
    public interface IAdIface : IBaseIface<AdModel>
    {
        List<AdModel> FilterByAdType(bool adtype);
        List<AdModel> GetAllInclude();
        List<AdModel> GetNewest();
        
        Task<List<AdModel>> Search(int? cat = 0,string title = "",string region = "", int mile = 1);
        AdModel GetInclude(int id);
        AdModel GetInclude(string url);
    }
}
