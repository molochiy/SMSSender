using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            Timer timer = new Timer(SendFinalStatus, null, TimeSpan.FromSeconds(5).Milliseconds, Timeout.Infinite);
            return Send(msg, cancellationToken);
        }

        private void SendFinalStatus(object state)
        {
            new HttpClient().PostAsync(CallbackUrl,
                new StringContent(JsonConvert.SerializeObject(GetFinalStatus()), Encoding.UTF8, "application/json")).Wait();
        }
    }
}
