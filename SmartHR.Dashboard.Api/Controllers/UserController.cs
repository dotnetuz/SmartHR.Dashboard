using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.User;
using SmartHR.Dashboard.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<User>> Create(User user)
        {
            var result = await _userService.CreateAsync(user);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll(int pageSize, int pageIndex)
            => Ok( await _userService.GetAllAsync(pageSize, pageIndex));

        [HttpGet("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            var result = await _userService.LoginAsync(username, password);

            return result.Error?.Code == 400 ? BadRequest("Username or password is incorrect") : Ok(result);
        }
    }
}
