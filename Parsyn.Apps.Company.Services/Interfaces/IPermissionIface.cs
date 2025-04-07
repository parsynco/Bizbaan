using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public interface IPermissionIface : IBaseIface<PermissionModel>
    {
        List<PermissionModel> GetLevelOne();
        PermissionModel GetById(int id);
        List<PermissionModel> TreeViewFriendly();
    }
}
