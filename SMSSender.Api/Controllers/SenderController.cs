using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SMSSender.Api.Controllers
{
    [Route("")]
    public class SenderController : ApiController
    {
        [Route("SendSMS")]
        // TODO: for testing purposes, change action method to HttpPost and launchUrl to some default
        [HttpGet]
        public async Task<IHttpActionResult> SendSms(string msg, CancellationToken cancellationToken, DateTime? startDate = null, DateTime? endDate = null)
        {
            string result = await Task.FromResult($"Message [{msg}] sent for users between {startDate} and {endDate}.")
                .ConfigureAwait(true);

            return Ok(result);
        }
    }
}
