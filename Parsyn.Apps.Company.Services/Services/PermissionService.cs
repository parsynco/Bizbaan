using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Service.Utiles.Helpers;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services
{
    public class PermissionService(PDBContext ctx, ILogger log) : BaseService<PermissionModel>(ctx, log), IPermissionIface
    {
        public new List<PermissionModel> GetAll()
        {
            var data = _dbObj.Include(x => x.Parent).ToList();
            return data;
        }
        public new ResponseObject Add(PermissionModel model)
        {
            var lastPerm = _dbObj.OrderByDescending(x => x.Id).FirstOrDefault();
            model.Code = lastPerm?.Code + 1 ?? 1000;
            return base.Add(model);
        }
        public PermissionModel GetById(int id)
        {
            return _dbObj.FirstOrDefault(x => x.Id == id);
        }
        public List<PermissionModel> GetLevelOne()
        {
            return [.. _dbObj.Where(x => x.Parent == null)];
        }

        public List<PermissionModel> TreeViewFriendly()
        {
            var firstlevel = _dbObj.Where(x => x.ParentId == null || x.ParentId == 0).Include(x => x.Childs);
            return [.. firstlevel];
        }
    }
}
