using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Bizbaan
{
    public class AdCategoryService(PDBContext ctx, ILogger log) : BaseService<AdCategoryModel>(ctx, log), IAdCategoryIface
    {
        public List<AdCategoryModel> GetAllInclude()
        {
            return [.. _dbObj.Include(x => x.Parent).Include(x => x.Seo).OrderBy(x => x.Sort)];
        }

        public List<AdCategoryModel> GetHierichal()
        {
            return [.. _dbObj.Where(x => x.ParentId == null)?.Include(x => x.Childs).ThenInclude(x => x.Childs).OrderBy(x => x.Sort)];
        }

        public AdCategoryModel GetInclude(int id)
        {
            return _dbObj.Where(x => x.Id == id)?.Include(x => x.Parent)?.Include(x => x.Seo)?.FirstOrDefault();
        }
        public AdCategoryModel GetIncludeOnlySeo(int id)
        {
            return _dbObj.Where(x => x.Id == id).Include(x => x.Seo)?.FirstOrDefault();
        }

        public List<AdCategoryModel> GetLevelOne()
        {
            var cats = _dbObj.Where(x => x.ParentId == null).Include(x => x.Seo).OrderBy(x => x.Sort).ToList();
            return cats;
        }

        public List<AdCategoryModel> GetLevelTwo()
        {
            var cats = _dbObj.Where(x => x.ParentId != null).Include(x => x.Seo).Include(x => x.Parent).ThenInclude(x => x.Seo).OrderBy(x => x.Sort).ToList();
            return cats;
        }
    }
}
