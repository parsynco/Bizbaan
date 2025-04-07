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
    public interface IAdCategoryIface : IBaseIface<AdCategoryModel>
    {
        List<AdCategoryModel> GetAllInclude();
        List<AdCategoryModel> GetLevelOne();
        List<AdCategoryModel> GetLevelTwo();
        List<AdCategoryModel> GetHierichal();
        AdCategoryModel GetInclude(int id);
    }
}
