using Enties;
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
    public class UserService : BaseServices<User>, IUserService
    {
        private readonly IUserRepository userDel;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userService):base(baseRepository)
        {
            userDel = userService;
        }

        public async Task<int> GetCount()
        {
            return await userDel.GetCount();
        }
    }
}
