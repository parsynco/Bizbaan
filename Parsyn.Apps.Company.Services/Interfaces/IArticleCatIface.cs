using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IArticleCatIface : IBaseIface<ArticleCategoryModel>
    {
        List<ArticleCategoryModel> GetAllIncludeSeo();
        Task<List<ArticleCategoryModel>> GetAllIncludeSeoAsync();
    }
}
