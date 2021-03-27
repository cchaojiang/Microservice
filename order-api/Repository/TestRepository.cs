using DataBaseService;
using IRepository;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class TestRepository<T> : BaseRepository<T>, ITestRepository<T> where T : class, new()
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
