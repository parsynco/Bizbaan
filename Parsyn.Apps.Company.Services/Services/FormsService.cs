using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Forms;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class FormsService(PDBContext ctx, ILogger log) : BaseService<FormModel>(ctx, log), IFormsIface
    {
    }
}
