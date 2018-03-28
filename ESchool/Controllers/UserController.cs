using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Common.DTO;
using ESchool.Common.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Controllers
{
    using Serilog;

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [Route("createUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreatedUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("User is Invalid");
            }

            try
            {
                Log.Information($"Attempt to creat new user");
                return Ok(await this.userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
