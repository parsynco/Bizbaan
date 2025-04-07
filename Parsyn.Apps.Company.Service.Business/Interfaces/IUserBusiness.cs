using AutoMapper;
using Parsin.Apps.Company.Data.Models.Dtos;
using Parsin.Apps.Company.Data.Models.Entity.User;
using Parsin.Apps.Company.Service.Business.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsin.Apps.Company.Service.Business.Interfaces
{
    public interface IUserBusiness:IBaseBusiness<UserModel>
    {
        UserModel Map(UserDto dto);
       
    }
}
