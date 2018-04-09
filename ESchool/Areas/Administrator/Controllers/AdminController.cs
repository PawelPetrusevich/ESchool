using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Areas.Administrator.Controllers
{
    using ESchool.Common.DTO;
    using ESchool.Common.Interface.Service;

    
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [Route("userBan")]
        [HttpPatch]
        public async Task<IActionResult> UserBanned([FromBody]int userId)
        {
            try
            {
                return this.Ok(await this.adminService.UserBanned(userId));
            }

            catch (ArgumentNullException e)
            {
                return this.BadRequest(e.Message);
            }

            catch (InvalidOperationException e)
            {
                return this.StatusCode(500, e.Message);
            }

            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
        }

        [Route("userDel")]
        [HttpPatch]
        public async Task<IActionResult> UserDeleted([FromBody]int userId)
        {
            try
            {
                return this.Ok(await this.adminService.UserDeleted(userId));
            }

            catch (ArgumentNullException e)
            {
                return this.BadRequest(e.Message);
            }

            catch (InvalidOperationException e)
            {
                return this.StatusCode(500, e.Message);
            }

            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
        }
    }
}