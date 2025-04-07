using Microsoft.AspNetCore.Mvc.RazorPages;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IPageIface : IBaseIface<PagesModel>
    {
        List<PagesModel> IncludeDependencies();
        ResponseObject AddOrUpdate(PagesModel model);
    }
}
