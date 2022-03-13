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
        private readonly IInterviewerService interviewerService;
        private readonly IUserService userService;
        public InterviewersController(IInterviewerService interviewerService, IUserService userService)
        {
            this.interviewerService = interviewerService;
            this.userService = userService;
        }


        [HttpGet, Authorize(Roles = "Applicant")]
        public async ValueTask<ActionResult<IEnumerable<Interview>>> GetInterviewers(int pageSize, int pageIndex)
        {
            var result = await this.userService.GetAllAsync(pageSize, pageIndex, user => user.Role == UserType.Interviewer);

            return Ok(result);
        }

        [HttpGet("interviews")]
        public async ValueTask<ActionResult<IEnumerable<Interview>>> GetInterviews(int pageSize, int pageIndex, InterviewStatus status)
        {
            var result = await this.interviewerService.GetRequestsAsync(pageSize, pageIndex, status);

            return Ok(result);
        }

        [HttpPatch("interview/toggle-status")]
        public async ValueTask<ActionResult<Interview>> UpdateStatus(UpdateInterviewStatusViewModel statusModel)
        {
            var result = await this.interviewerService.UpdateStatusAsync(statusModel);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        } 

        [HttpPost]
        public async ValueTask<IActionResult> LeaveFeedback(
            [FromBody] FeedbackViewModel feedback)
        {
            var result = await this.interviewerService.LeaveFeedbackAsync(feedback);

            return Created("", result);
        }
    }
}
