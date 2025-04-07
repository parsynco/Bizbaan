using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Bizbaan
{
    public class AdsIMagesService(PDBContext ctx, ILogger log) : BaseService<AdImageModel>(ctx, log), IAdsImagesIface
    {
        public List<AdImageModel> GetAllInclude()
        {
            return [.. _dbObj.Include(x => x.Ad).Include(x => x.Media)];
        }
    }
}
