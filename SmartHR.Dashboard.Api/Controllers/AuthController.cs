using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<User>> Create(UserViewModel user)
        {
            var result = await userService.CreateAsync(user);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        }

        [HttpGet("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            var result = await userService.LoginAsync(username, password);

            return result.Error?.Code == 400 ? BadRequest("Username or password is incorrect") : Ok(result);
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll
            (int pageSize, int pageIndex)
        {

            return Ok(await this.userService.GetAllAsync(pageSize: pageSize, pageIndex: pageIndex));
        }
    }
}
