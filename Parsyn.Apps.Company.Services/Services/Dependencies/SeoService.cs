using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Dependencies
{
    public class SeoService(PDBContext ctx, ILogger log) : BaseService<SeoModel>(ctx, log), ISeoIface
    {
        public ResponseObject AddOrUpdate(SeoModel model)
        {
            var item = Get(x => x.Id == model.Id);
            if (item is null)
            {
                return Add(model);
            }
            else
            {
                return Update(model);
            }

        }
        public bool ExistsUrl(string url)
        {
            return _dbObj.Any(x => x.Url == url);
        }

        public async Task<bool> ExistsUrlAsync(string url)
        {
            return await _dbObj.AnyAsync(x => x.Url == url);
        }

        public SeoModel Get(int id)
        {
            return _dbObj.FirstOrDefault(x => x.Id == id);
        }
    }
}
