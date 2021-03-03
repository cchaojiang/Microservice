using Common.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        AppSettings _appset;
        public HelloController(AppSettings   appSettings  )
        {
            _appset = appSettings;
        }
        /// <summary>
        /// Hello 请求
        /// </summary>
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}
