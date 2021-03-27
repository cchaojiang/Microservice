using System;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ITestRepository<T> where T:class
    {
        public int Sum(int i, int j);
    }
}
