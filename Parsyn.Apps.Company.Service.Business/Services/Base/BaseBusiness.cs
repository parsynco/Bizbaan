using AutoMapper;
using Parsin.Apps.Company.Service.Business.Interfaces.Base;
using Parsin.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsin.Apps.Company.Service.Utiles.Helpers;
using Parsin.Apps.Company.Services.Interfaces.Base;
using Parsin.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Parsin.Apps.Company.Service.Business.Services.Base
{
    public class BaseBusiness<T> where T : class, IBaseBusiness<T>
    {
        private readonly IBaseIface<T> _srvc;
        public BaseBusiness(BaseService<T> srvc)
        {
            _srvc = srvc;
        }
        public ResponseObject Add(T model)
        {
            return _srvc.Add(model);
        }

        public async Task<ResponseObject> AddAsync(T model)
        {
            return await  _srvc.AddAsync(model);
        }

        public ResponseObject Delete(Expression<Func<T, bool>> exp)
        {
            return _srvc.Delete(exp);
        }

        public async Task<ResponseObject> DeleteAsync(Expression<Func<T, bool>> exp)
        {
            return await _srvc.DeleteAsync(exp);
        }

        public ResponseObject Get(Expression<Func<T, bool>> exp)
        {
            return _srvc.Get(exp);
        }

        public ResponseObject GetAll(int from, int size)
        {
            return _srvc.GetAll(from,size);
        }

        public ResponseObject GetAll(Expression<Func<T, bool>> exp, int from, int size)
        {
            return _srvc.GetAll(exp,from,size);
        }

        public async Task<ResponseObject> GetAllAsync(int from, int size)
        {
            return await _srvc.GetAllAsync(from, size);
        }

        public async Task<ResponseObject> GetAllAsync(Expression<Func<T, bool>> exp, int from, int size)
        {
            return await _srvc.GetAllAsync(exp,from, size);
        }

        public async Task<ResponseObject> GetAsync(Expression<Func<T, bool>> exp)
        {
            return await _srvc.GetAsync(exp);
        }

        public ResponseObject Update(T model)
        {
            return _srvc.Update(model);
        }

        public async Task<ResponseObject> UpdateAsync(T model)
        {
            return await _srvc.UpdateAsync(model);
        }
    }
}
