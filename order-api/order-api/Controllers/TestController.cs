using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService test;
        public TestController(ITestService _test)
        {
            test = _test;
        }

        [HttpGet]
        public IActionResult Sum(int i, int j)
        {
            return Ok(test.sum(i, j));
        }
    }
}
