using Enties;
using IRepository;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService user_service;
        public UsersController(IUserService userService)
        {
            user_service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string id)
        {
            User user = await user_service.QueryById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            bool res = await user_service.Add(user);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            bool res = await user_service.Update(user);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(object[] ids)
        {
            bool res = await user_service.DeleteByIds(ids);
            return Ok(res);
        }

        public async Task<IActionResult> AutoFac()
        {
            int count = await user_service.GetCount();
            return Ok(count);
        }
    }
} 
