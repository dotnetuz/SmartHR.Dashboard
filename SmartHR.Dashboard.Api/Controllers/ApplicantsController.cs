using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Entities.Users;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize(Roles = "Applicant, Admin")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IUserService _userService;
        public ApplicantsController(IApplicantService applicantService, IInterviewerService interviewService, IUserService userService)
        {
            _applicantService = applicantService;
            _userService = userService;
        }

        [HttpPost("request")]
        public async ValueTask<ActionResult<Interview>> SendRequest(InterviewViewModel interview)
        {
            var result = await _applicantService.SendRequestAsync(interview);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        }

        [HttpGet("interviews")]
        public async ValueTask<ActionResult<IEnumerable<Interview>>> GetInterviews(int pageSize, int pageIndex)
        {
            var result = await _applicantService.GetFinishedInterviewsAsync(pageSize, pageIndex);

            return Ok(result);
        }

        [HttpGet, Authorize(Roles = "Applicant, Admin")]
        public async ValueTask<ActionResult<IEnumerable<User>>> GetInterviewers(int pageSize, int pageIndex)
        {
            var result = await this._userService.GetAllAsync(pageSize, pageIndex, user => user.Role == UserType.Interviewer);

            return Ok(result);
        }
    }
}
