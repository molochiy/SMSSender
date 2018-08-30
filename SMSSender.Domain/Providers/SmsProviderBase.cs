using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Common.Config;
using SMSSender.Entities.Dtos;
using SMSSender.Entities.Models;

namespace SMSSender.Domain.Providers
{
    public abstract class SmsProviderBase
    {
        private string CallbackUrl { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.SmsProviderCallbackUrl];

        protected SmsProviderBase(string phoneNumber)
        {
            To = phoneNumber;
        }

        protected string From { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.SmsProviderSenderPhoneNumber];

        protected string To { get; }

        protected abstract SmsFinalStatus GetFinalStatus();

        protected abstract Task<SentSmsInfo> Send(string msg, CancellationToken cancellationToken);

        public Task<SentSmsInfo> SendSms(string msg, CancellationToken cancellationToken)
        {
            return Send(msg, cancellationToken);

            // TODO: Run in timer
            // this.SendFinalStatus();
        }

        private Task SendFinalStatus()
        {
            // use httpclient
            // use callbackurl and GetFinalStatus as data
            return Task.CompletedTask;
        }
    }
}
