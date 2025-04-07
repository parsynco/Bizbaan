using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Service.Utiles.Helpers;
using Parsyn.Apps.Company.Service.Utiles.Utiles;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Base
{
    public class BaseService<T> : IBaseIface<T> where T : class
    {
        public readonly PDBContext _ctx;
        public readonly DbSet<T> _dbObj;
        public readonly RespGeneratorSrvc _rsp;
        public readonly ILogger _log;
        public BaseService(PDBContext ctx, ILogger log)
        {
            _ctx ??= ctx;
            _dbObj = _ctx.Set<T>();
            _rsp = new RespGeneratorSrvc();
            _log = log;
        }

        public ResponseObject Add(T model)
        {
            var res = _dbObj.Add(model);
            if (res is null)
                return _rsp.MapError();
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }

        public async Task<ResponseObject> AddAsync(T model)
        {
            try
            {
                var res = await _dbObj.AddAsync(model);
                if (res is null)
                    return _rsp.MapError("خطا در ثبت اطلاعات");
                await _ctx.SaveChangesAsync();
                return _rsp.MapOk("رکورد مورد نظر با موفقیت ثبت شد.");
            }
            catch (Exception ex)
            {
                return _rsp.MapUnhandeled(ex.Message, ex);
            }
        }

        public ResponseObject Delete(Expression<Func<T, bool>> exp)
        {
            _dbObj.Where(exp).ExecuteDelete();
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }

        public async Task<ResponseObject> DeleteAsync(Expression<Func<T, bool>> exp)
        {
            await _dbObj.Where(exp).ExecuteDeleteAsync();
            await _ctx.SaveChangesAsync();
            return _rsp.MapOk();
        }

        public ResponseObject Get(Expression<Func<T, bool>> exp)
        {
            T obj = _dbObj?.AsNoTracking().FirstOrDefault(exp);
            return _rsp.MapOk(data: obj);
        }
        public async Task<ResponseObject> GetAsync(Expression<Func<T, bool>> exp)
        {
            T obj = await _dbObj?.AsNoTracking().FirstOrDefaultAsync(exp);
            return _rsp.MapOk(data: obj);
        }
        public ResponseObject GetAll(int from, int size)
        {
            List<T> objs = (size > 0) ? _dbObj.AsNoTracking().Skip(size * from).Take(size).ToList() : _dbObj.AsNoTracking().ToList();
            return _rsp.MapOk(data: objs);
        }

        public async Task<ResponseObject> GetAllAsync(int from, int size)
        {
            List<T> objs = (size > 0) ? await _dbObj.AsNoTracking().Skip(size * from).Take(size).ToListAsync() : await _dbObj.AsNoTracking().ToListAsync();
            return _rsp.MapOk(data: objs);
        }


        public ResponseObject Update(T model)
        {
            _dbObj.Update(model);
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }

        public async Task<ResponseObject> UpdateAsync(T model)
        {
            _dbObj.Update(model);
            await _ctx.SaveChangesAsync();
            return _rsp.MapOk();
        }

        public ResponseObject GetAll(Expression<Func<T, bool>> exp, int from, int size)
        {
            IQueryable<T> objs = _dbObj.Where(exp).AsNoTracking().Skip(size * from).Take(size);
            return _rsp.MapOk(data: objs);
        }

        public async Task<ResponseObject> GetAllAsync(Expression<Func<T, bool>> exp, int from, int size)
        {
            IQueryable<T> objs = _dbObj.Where(exp).AsNoTracking().Skip(size * from).Take(size);
            return _rsp.MapOk(data: objs);
        }

        public bool ExistsById(Expression<Func<T, bool>> exp)
        {
            return _dbObj.Any(exp);
        }

        public async Task<bool> ExistsByIdAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbObj.AnyAsync(exp);
        }

        public List<T> GetAll()
        {
            return [.. _dbObj.Where(x => true)];
        }

        public ResponseObject UpdateAll(T[] model)
        {
            _dbObj.UpdateRange(model);
            _ctx.SaveChanges();
            return _rsp.MapOk();
        }

        public List<T> GetListPaged(Expression<Func<T, T>> exp, int page = 0, int size = 100)
        {
            return [.. _dbObj.Select(exp).Page(page, size)];
        }

        public async Task<List<T>> GetListPagedAsync(Expression<Func<T, T>> exp, int page = 0, int size = 100)
        {
            return await _dbObj.Select(exp).Page(page, size).ToListAsync();
        }

        public List<T> GetToList(Expression<Func<T, bool>> exp)
        {
            var lst = _dbObj?.AsNoTracking().Where(exp).ToList();
            return lst;
        }
    }
}
