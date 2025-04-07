using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Service.Utiles.Utiles;
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
    public class ArticleService(PDBContext ctx, ILogger log) : BaseService<ArticleModel>(ctx, log), IArticleIface
    {

        public new ResponseObject Get(Expression<Func<ArticleModel, bool>> exp)
        {
            var data = _dbObj.Where(exp).Include(x => x.Seo).FirstOrDefault();
            return _rsp.MapOk(data: data);
        }

        public ArticleModel GetById(int id)
        {
            var item = _dbObj.Include(x => x.Seo).FirstOrDefault(x => x.Id == id) ?? throw new Exception("Item not found");
            return item;
        }

        public async Task<ArticleModel> GetByIdAsync(int id)
        {
            var item = await _dbObj.Include(x => x.Seo).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Item not found");
            return item;
        }

        public async Task<List<ArticleModel>> RandomListPaged(int page, string q = null, int size = 20)
        {
            var data = string.IsNullOrEmpty(q) ? _dbObj.
                Include(x => x.Seo).
                Include(x => x.ArticleCategory).
                ThenInclude(x => x.Seo).
                OrderByDescending(x => x.Created_At).
                Page(page, size) :
                _dbObj.
                Where(x => (x.Title.Contains(q) || x.Description.Contains(q) || x.ShortDescription.Contains(q))).
                Include(x => x.Seo).
                Include(x => x.ArticleCategory).
                ThenInclude(x => x.Seo).
                OrderByDescending(x => x.Created_At).
                Page(page, size)
                ;
            return await data.ToListAsync();
        }

        public async Task<List<ArticleModel>> RandomListPaged(int cat, int page, string q = null, int size = 20)
        {
            var data = string.IsNullOrEmpty(q) ? _dbObj.Where(x => x.CategoryId == cat).
                Include(x => x.Seo).
                Include(x => x.ArticleCategory).
                ThenInclude(x => x.Seo).
                OrderByDescending(x => x.Created_At).
                Page(page, size) :
                _dbObj.Where(x => x.CategoryId == cat && (x.Title.Contains(q) || x.Description.Contains(q) || x.ShortDescription.Contains(q))).
                Include(x => x.Seo).
                Include(x => x.ArticleCategory).
                ThenInclude(x => x.Seo).
                OrderByDescending(x => x.Created_At).
                Page(page, size)
                ;
            return await data.ToListAsync();
        }
    }
}
