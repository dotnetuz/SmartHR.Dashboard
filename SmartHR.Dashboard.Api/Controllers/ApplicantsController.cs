using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize(Roles = "Applicant")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Interview>> SendRequest(InterviewViewModel interview)
        {
            var result = await _applicantService.SendRequestAsync(interview);

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        }
    }
}
