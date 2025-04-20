using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Bizbaan
{
    public class AdService(PDBContext ctx, ILogger log, IZipIface zipsrvc) : BaseService<AdModel>(ctx, log), IAdIface
    {
        private readonly IZipIface _zipsrvc = zipsrvc;

        public List<AdModel> FilterByAdType(bool adtype)
        {
            var data = _dbObj.Where(x => x.IsSpecial == adtype).OrderBy(x => x.Sort).Include(x => x.Seo).Include(x => x.Category).Include(x => x.Zip).ToList();
            return data;
        }

        public List<AdModel> GetAllInclude()
        {
            return [.. _dbObj.Include(x => x.Seo).OrderBy(x => x.Sort).Include(x => x.Category).Include(x => x.Zip)];
        }

        public AdModel GetInclude(int id)
        {
            var data = _dbObj.Where(x => x.Id == id).Include(x => x.Images).ThenInclude(x => x.Media).Include(x => x.Seo).Include(x => x.Category).ThenInclude(x => x.Parent).Include(x => x.Zip).FirstOrDefault();
            return data;
        }

        public AdModel GetInclude(string url)
        {
            var data = _dbObj.Include(x => x.Seo).Where(x => x.Seo.Url.ToLower() == url.ToLower()).Include(x => x.Images).ThenInclude(x => x.Media).Include(x => x.Category).ThenInclude(x => x.Parent).Include(x => x.Zip).FirstOrDefault();
            return data;
        }

        public List<AdModel> GetNewest()
        {
            return [.. _dbObj.OrderByDescending(x => x.Created_At).OrderBy(x => x.Sort).Include(x => x.Zip).Include(x => x.Seo).Include(x => x.Category).Take(4)];
        }


        public async Task<List<AdModel>> Search(int? cat = 0, string title = "", string region = "", int mile = 1)
        {
            var data = _dbObj.Include(x => x.Category).ThenInclude(x => x.Parent).Include(x => x.Zip).Include(x => x.Seo).AsEnumerable();
            if (cat != 0 && cat != null)
            {
                data = data.Where(x => x.Category?.Parent?.Id == cat || x.CategoryId == cat);
            }
            if (!string.IsNullOrEmpty(title))
            {
                data = data.Where(x => x.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(region))
            {
                var zip = _zipsrvc.Find(region);
                if (zip != null)
                {
                    if (mile > 1)
                    {
                        var zipsInRadius = (await _zipsrvc.GetZipCodesInRadius(double.Parse(zip.Latitude.ToString()), double.Parse(zip.Longitude.ToString()), mile)).OrderBy(x => x.Distance).Select(x => x.Zipcode).ToList();
                        data = data.Where(x => zipsInRadius.Contains(x.Zip.Zipcode));
                    }
                }
            }
            return data.OrderBy(x => x.Sort).ToList();
        }
    }
}
