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
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        
        [Route("createUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("User is Invalid");
            }

            try
            {
                return Ok(await _userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
