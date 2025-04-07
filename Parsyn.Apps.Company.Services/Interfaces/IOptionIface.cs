using Parsyn.Apps.Company.Data.Models.Entity;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IOptionIface:IBaseIface<OptionsModel>
    {
        Task<ResponseObject> GetAs<T>(string key);
        Task<T> GetAsModel<T>(string key);
        ResponseObject AddOrUpdate(OptionsModel model);
    }
}
