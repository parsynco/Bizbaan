using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces.Dependencies
{
    public interface ISeoIface:IBaseIface<SeoModel>
    {
        SeoModel Get(int id);
        Task<bool> ExistsUrlAsync(string url);
        bool ExistsUrl(string url);
        public ResponseObject AddOrUpdate(SeoModel model);
    }
}
