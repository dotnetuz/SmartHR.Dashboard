using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.User;
using SmartHR.Dashboard.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost("approvement")]
        public async Task<IActionResult> CompleteRegistrationAsync(
            [FromBody]IList<long> userIdentities, 
            [FromQuery] bool isApproved)
        {
            if (userIdentities is null || userIdentities.Count == 0)
                return BadRequest("You have at least a member to approve registration");

            await this.adminService.CompleteRegistrationAsync(userIdentities, isApproved);

            return NoContent();
        }
    }
}
