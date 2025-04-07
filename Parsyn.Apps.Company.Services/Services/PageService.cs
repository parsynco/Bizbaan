using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class PageService(PDBContext ctx, ILogger log) : BaseService<PagesModel>(ctx, log), IPageIface
    {
        public ResponseObject AddOrUpdate(PagesModel model)
        {
            var item = Get(x => x.Name == model.Name);
            if (item is null)
            {
                return Add(model);
            }
            else
            {
                return Update(model);
            }

        }

        public List<PagesModel> IncludeDependencies()
        {
            return [.. _dbObj.Include(x => x.Seo)];
        }
    }
}
