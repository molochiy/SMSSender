using SMSSender.Entities.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using SMSSender.Domain.Services;

namespace SMSSender.Api.Controllers
{
    [Route("")]
    public class SenderController : ApiController
    {
        private readonly ISmsSenderService _smsSenderService;

        public SenderController(ISmsSenderService smsSenderService)
        {
            _smsSenderService = smsSenderService;
        }

        [Route("SendSMS")]
        [HttpPost]
        public async Task<IHttpActionResult> SendSms(string msg, CancellationToken cancellationToken, DateTime? startDate = null, DateTime? endDate = null)
        {
            string result = await Task.FromResult($"Message [{msg}] sent for users between {startDate} and {endDate}.")
                .ConfigureAwait(true);

            return Ok(result);
        }

        [Route("smscallback")]
        [HttpPost]
        public async Task<IHttpActionResult> SendSms(SmsFinalStatus finalStatus, CancellationToken cancellationToken)
        {
            await _smsSenderService.UpdateSmsStatus(finalStatus, cancellationToken).ConfigureAwait(true);
            return Ok();
        }
    }
}
