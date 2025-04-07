using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces.Bizbaan
{
    public interface IZipIface : IBaseIface<ZipModel>
    {
        IEnumerable<ZipModel> GetLightPaged(int page,int size = 100);
        IEnumerable<ZipModel> GetLightPaged(int page,string q,int size = 100);
        Task<List<ZipModel>> GetZipCodesInRadius(double latitude, double longitude, double radius);
        int GetPageCount();
        ZipModel Find(string zipcode);
    }
}
