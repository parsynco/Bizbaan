using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.User;
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
    public class RolePermissionService(PDBContext ctx, ILogger log) : BaseService<RolePermissionModel>(ctx, log), IRolePermissionIface
    {
        public ResponseObject UpdateList(List<RolePermissionModel> item)
        {
            if (item is null)
                return _rsp.MapError("Model is null or empty.");

            Delete(x => x.RoleId == item.FirstOrDefault().RoleId);
            _dbObj.AddRange(item);
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }
    }
}
