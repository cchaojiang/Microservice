using DataBaseService;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : DbContext<T>, IBaseRepository<T> where T : class, new()
    {
        public async Task<bool> Add(T model)
        {
            var i = await Task.Run(() => db_client.Insertable(model).ExecuteCommand());
            return i > 0;
        }

        public async Task<T> QueryById(object obj_id)
        {
            return await Task.Run(() => db_client.Queryable<T>().InSingle(obj_id));
        }

        public async Task<bool> Update(T model)
        {
            var i = await Task.Run(() => db_client.Updateable(model).ExecuteCommand());
            return i > 0;
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            var i = await Task.Run(() => db_client.Deleteable<T>().In(ids).ExecuteCommand());
            return i > 0;
        }
    }
}
