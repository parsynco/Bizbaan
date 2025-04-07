using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Config;
using Parsyn.Apps.Company.Services.Interfaces.Config;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Config
{
    public class MediaCatService(PDBContext ctx, ILogger log) : BaseService<MediaCatModel>(ctx, log), IMediaCatIface
    {
    }
}
