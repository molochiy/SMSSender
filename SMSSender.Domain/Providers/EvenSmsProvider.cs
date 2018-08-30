using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Common.Config;
using SMSSender.Common.Enums;
using SMSSender.Entities.Dtos;
using SMSSender.Entities.Models;

namespace SMSSender.Domain.Providers
{
    public class EvenSmsProvider : SmsProviderBase, ISmsProvider
    {
        private string Url { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.EvenSmsProviderUrl];

        private string CompanyId { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.EvenSmsProviderCompanyId];

        private string Password { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.EvenSmsProviderPassword];


        // for faking only
        private string lastSentMsgId;

        public EvenSmsProvider(string phoneNumber) : base(phoneNumber)
        {
        }

        protected override SmsFinalStatus GetFinalStatus()
        {
            return new EvenProviderSmsFinalStatus
            {
                ExternalMessageId = lastSentMsgId,
                Status = MessageStatus.Delivered // or MessageStatus.Failed
            };
        }

        protected override Task<SentSmsInfo> Send(string msg, CancellationToken cancellationToken)
        {
            lastSentMsgId = Guid.NewGuid().ToString();

            // there we can use Url, CompanyId and Password
            return Task.FromResult<SentSmsInfo>(new EvenProviderSentSmsInfo
            {
                From = From,
                To = To,
                MsgId = lastSentMsgId,
                Status = MessageStatus.InProgress // or MessageStatus.Failed
            });
        }
    }
}