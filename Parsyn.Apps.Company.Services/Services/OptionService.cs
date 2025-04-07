using Microsoft.EntityFrameworkCore;
using Serilog;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
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
    public class OptionService(PDBContext ctx, ILogger log) : BaseService<OptionsModel>(ctx, log), IOptionIface
    {
        public async Task<ResponseObject> GetAs<T>(string key)
        {
            var fnd = await _dbObj.FirstOrDefaultAsync(x => x.Key == key);
            if (fnd is null)
                return default;
            return _rsp.MapOk(data: JsonConvert.DeserializeObject<T>(fnd.Value));
        }
        public ResponseObject AddOrUpdate(OptionsModel model)
        {
            var item = _dbObj.AsNoTracking().FirstOrDefault(x => x.Key == model.Key);
            if (item is null)
            {
                return Add(model);
            }
            else
            {
                model.Id = item.Id;
                return Update(model);
            }

        }

        public async Task<T> GetAsModel<T>(string key)
        {
            var fnd = await _dbObj.FirstOrDefaultAsync(x => x.Key == key);
            if (fnd is null)
                return default;
            return JsonConvert.DeserializeObject<T>(fnd.Value);
        }
    }
}
