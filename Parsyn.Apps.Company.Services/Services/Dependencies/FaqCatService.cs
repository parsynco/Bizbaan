using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Base;
using Parsyn.Apps.Company.Data.Models.Entity.Landing;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Dependencies
{
    public class FaqCatService(PDBContext ctx, ILogger log) : BaseService<FaqCatModel>(ctx, log), IFaqCatIface
    {
        public List<FaqCatModel> IncludeChilds()
        {
            List<FaqCatModel> result = [.. _dbObj.Include(x => x.Faqs).Include(x => x.Seo)];
            return result;
        }
    }
}
