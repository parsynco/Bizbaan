using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Reactions;
using Parsyn.Apps.Company.Services.Interfaces.Dependencies;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Dependencies
{
    public class VisitService(PDBContext ctx, ILogger log) : BaseService<VisitModel>(ctx, log), IVisitIface
    {
    }
}
