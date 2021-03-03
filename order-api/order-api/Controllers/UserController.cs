using Common.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        public UserController(ILogger<UserController> log)
        {
            _logger = log;
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetUser(string user )
        {
            return Ok(user);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if (role != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModel tokenModel = new TokenModel { Uid = "abcde", Role = role };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
    }
}
