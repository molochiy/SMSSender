using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMSSender.Api.Controllers
{
    [Route("")]
    public class SenderController : Controller
    {
        [Route("SendSMS")]
        // TODO: for testing purposes, change action method to HttpPost and launchUrl to some default
        [HttpGet]
        public async Task<IActionResult> SendSms([FromQuery]string msg, [FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate)
        {
            string result = await Task.FromResult($"Message [{msg}] sent for users between {startDate} and {endDate}.")
                .ConfigureAwait(true);

            return Ok(result);
        }
    }
}
