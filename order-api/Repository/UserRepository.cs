using Enties;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository()
        {
            db_client.CodeFirst.InitTables<User>();    //CodeFirst
        }

        public async Task<int> GetCount()
        {
            var i = await Task.Run(() => current_db.AsQueryable().Count());
                return i;
        }
    }
}
