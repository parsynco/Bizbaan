using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces.Base
{
    public interface IBaseIface<T>
    {
        List<T> GetAll();

        List<T> GetListPaged(Expression<Func<T, T>> exp, int page = 0, int size = 100);
        Task<List<T>> GetListPagedAsync(Expression<Func<T, T>> exp, int page = 0,int size = 100);
        ResponseObject Add(T model);
        ResponseObject Update(T model);
        ResponseObject UpdateAll(T[] model);
        ResponseObject Delete(Expression<Func<T,bool>> exp);
        ResponseObject Get(Expression<Func<T, bool>> exp);
        List<T> GetToList(Expression<Func<T, bool>> exp);
        ResponseObject GetAll(int from,int size);
        ResponseObject GetAll(Expression<Func<T, bool>> exp,int from,int size);
        bool ExistsById(Expression<Func<T, bool>> exp);
        #region Async/Await
        Task<ResponseObject> AddAsync(T model);
        Task<ResponseObject> UpdateAsync(T model);
        Task<ResponseObject> DeleteAsync(Expression<Func<T, bool>> exp);
        Task<ResponseObject> GetAsync(Expression<Func<T, bool>> exp);
        Task<ResponseObject> GetAllAsync(int from, int size);
        Task<ResponseObject> GetAllAsync(Expression<Func<T, bool>> exp, int from, int size);
        Task<bool> ExistsByIdAsync(Expression<Func<T, bool>> exp);
        #endregion
    }
}
