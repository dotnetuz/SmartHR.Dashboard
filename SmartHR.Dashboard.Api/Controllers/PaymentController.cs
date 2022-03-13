using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartHR.Dashboard.Domain.Models.Payme;
using SmartHR.Dashboard.Service.Helpers;
using SmartHR.Dashboard.Service.Interfaces;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Api.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymeService paymeService;
        private readonly IConfiguration config;
        public PaymentController(IPaymeService paymeService, IConfiguration config)
        {
            this.paymeService = paymeService;
            this.config = config;
        }

        /// <summary>
        /// Payme merchant api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("payme")]
        public async Task<ActionResult<PaymeResponse<object>>> Integration(PaymeRequest request)
        {
            string authHeader = Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                var credentials = BasicAuthHelper.GetCredentials(authHeader);

                var username = config["Payme:Basic:Username"].ToString();
                var password = config["Payme:Basic:Password"].ToString();

                if (username.Equals(credentials.username) && password.Equals(credentials.password))
                    return Ok(await paymeService.PerformAsync(request));
                else
                    return BadRequest(new PaymeResponse<object>
                    {
                        Error = new PaymeErrorModel
                        {
                            Code = StatusCodes.Status400BadRequest,
                            Message = "Login or password incorrect",
                            Data = username + ":" + password
                        }
                    });
            }

            return Ok(new PaymeResponse<object>
            {
                Error = new PaymeErrorModel
                {
                    Code = -32504,
                    Message = "Auth is invalid",
                    Data = "payment"
                }
            });
        }
    }
}
