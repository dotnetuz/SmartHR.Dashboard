using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTechnology([FromBody] TechnologyViewModel technologyViewModel)
        {
            return Created("", await this.technologyService.CreateAsync(technologyViewModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnologies(int pageSize, int pageIndex)
        {
            return Ok(await this.technologyService.GetAllAsync(pageSize: pageSize, pageIndex: pageIndex));
        }
    }
}
