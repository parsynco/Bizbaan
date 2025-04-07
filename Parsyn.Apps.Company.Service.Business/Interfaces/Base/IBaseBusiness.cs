using Parsin.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsin.Apps.Company.Service.Business.Interfaces.Base
{
    public interface IBaseBusiness<T>
    {
        ResponseObject Add(T model);
        ResponseObject Update(T model);
        ResponseObject Delete(Expression<Func<T, bool>> exp);
        ResponseObject Get(Expression<Func<T, bool>> exp);
        ResponseObject GetAll(int from, int size);
        ResponseObject GetAll(Expression<Func<T, bool>> exp, int from, int size);

        #region Async/Await
        Task<ResponseObject> AddAsync(T model);
        Task<ResponseObject> UpdateAsync(T model);
        Task<ResponseObject> DeleteAsync(Expression<Func<T, bool>> exp);
        Task<ResponseObject> GetAsync(Expression<Func<T, bool>> exp);
        Task<ResponseObject> GetAllAsync(int from, int size);
        Task<ResponseObject> GetAllAsync(Expression<Func<T, bool>> exp, int from, int size);
        #endregion
    }
}
