using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    public class AdminsController : ControllerBase
    {
        private readonly IUserService userService;

        public AdminsController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
