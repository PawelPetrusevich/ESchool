namespace ESchool.Areas.Users.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ESchool.Common.DTO;
    using ESchool.Common.Interface.Service;
    using ESchool.Properties;

    using Microsoft.AspNetCore.Mvc;

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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(Resources.InValidData);
            }

            try
            {
                Log.Information($"Attempt to creat new user");
                return this.Ok(await this.userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Route("AddUserSettings/{userId}")]
        [HttpPost]
        public async Task<IActionResult> AddUserSettings([FromBody] ModifiUserSettingsDTO userSettings, [FromRoute] int userId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(Resources.InValidData);
            }

            try
            {
                Log.Information($"Attempt modificate the user settings");
                return this.Ok(await this.userService.AddUserSettings(userSettings, userId));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
