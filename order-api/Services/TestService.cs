using IServices;
using Repository;
using System;
using IRepository;

namespace Services
{
    public class TestService : ITestService
    {
        public int sum(int i, int j)
        {
            return i + j;
        }
    }
}
