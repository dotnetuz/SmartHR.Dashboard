using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize(Roles = "Interviewer")]
    public class InterviewersController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;
        public InterviewersController(IInterviewerService interviewerService)
        {
            _interviewerService = interviewerService; 
        }

        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<Interview>>> GetInterviewers(int pageSize, int pageIndex, InterviewStatus status)
        {
            var result = await _interviewerService.GetRequestsAsync(pageSize, pageIndex, status);

            return Ok(result);
        }

        [HttpPatch("interview/toggle-status")]
        public async ValueTask<ActionResult<Interview>> UpdateStatus(UpdateInterviewStatusViewModel statusModel)
        {
            var result = await _interviewerService.UpdateStatusAsync(statusModel);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        } 
    }
}
