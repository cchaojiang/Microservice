using Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IUserService : IBaseServices<User>
    {
        Task<int> GetCount();
    }
}
