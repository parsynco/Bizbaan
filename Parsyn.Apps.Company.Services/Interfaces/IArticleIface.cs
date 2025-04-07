using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IArticleIface:IBaseIface<ArticleModel>
    {
        Task<List<ArticleModel>> RandomListPaged(int page, string q = null, int size = 20);
        Task<List<ArticleModel>> RandomListPaged(int cat,int page, string q = null, int size = 20);
        ArticleModel GetById(int id);
        Task<ArticleModel> GetByIdAsync(int id);

    }
}
