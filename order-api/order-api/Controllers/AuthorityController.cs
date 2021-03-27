using Common.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private ILogger<AuthorityController> _logger;
        public AuthorityController(ILogger<AuthorityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Policy ="Admin")]
        public IActionResult Admin()
        {
            return Ok("this is admin response");
        }

        [HttpGet]
        [Authorize(Policy ="System")]
        public IActionResult System()
        {
            return Ok("this is system response");
        }

        [HttpGet]
        [Authorize]
        public IActionResult PraseToken()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var model = JwtHelper.SerializeJwt(token);
            return Ok(model);
        }

    }
}
