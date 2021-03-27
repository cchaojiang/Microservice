using IRepository;
using IServices;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
        private readonly IBaseRepository<T> baseDal;

        public BaseServices(IBaseRepository<T> baseRepository)
        {
            baseDal = baseRepository;
        }
        public async Task<T> QueryById(object obj_id)
        {
            return await baseDal.QueryById(obj_id);
        }
        public async Task<bool> Add(T model)
        {
            return await baseDal.Add(model);
        }
        public async Task<bool> Update(T model)
        {
            return await baseDal.Update(model);
        }
        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await baseDal.DeleteByIds(ids);
        }
    }
}
