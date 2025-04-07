using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class ArticleCatService(PDBContext ctx, ILogger log) : BaseService<ArticleCategoryModel>(ctx, log), IArticleCatIface
    {

        public new ResponseObject Get(Expression<Func<ArticleCategoryModel, bool>> exp)
        {
            var data = _dbObj.Where(exp).Include(x => x.Seo).FirstOrDefault();
            return _rsp.MapOk(data: data);
        }

        public List<ArticleCategoryModel> GetAllIncludeSeo()
        {
            return [.. _dbObj.Include(x => x.Seo)];
        }

        public async Task<List<ArticleCategoryModel>> GetAllIncludeSeoAsync()
        {
            var data = await _dbObj.Include(x => x.Articles).Include(x => x.Seo).ToListAsync();
            return data;
        }
    }
}
