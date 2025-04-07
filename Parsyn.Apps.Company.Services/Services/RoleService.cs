using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class RoleService(PDBContext ctx, ILogger log) : BaseService<RoleModel>(ctx, log), IRoleIbase
    {
        public new List<RoleModel> GetAll()
        {
            var data = _dbObj.Include(x => x.Permissions).ToList();
            return data;
        }
    }
}
