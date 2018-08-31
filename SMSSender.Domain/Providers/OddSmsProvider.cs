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
    public class OddSmsProvider : SmsProviderBase, ISmsProvider
    {
        private string Url { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.OddSmsProviderUrl];

        private string Username { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.OddSmsProviderUsername];

        private string Password { get; } =
            ConfigurationManager.AppSettings[ConfigKeyConstants.OddSmsProviderPassword];

        // for faking only
        private string lastSentMsgId;

        public OddSmsProvider(string phoneNumber) : base(phoneNumber)
        {
        }

        protected override SmsFinalStatus GetFinalStatus()
        {
            return new SmsFinalStatus
            {
                ExternalMessageId = lastSentMsgId,
                TimeOfSending = DateTime.UtcNow,
                Status = MessageStatus.Delivered // or MessageStatus.Failed
            };
        }

        protected override Task<SentSmsInfo> Send(string msg, CancellationToken cancellationToken)
        {
            lastSentMsgId = Guid.NewGuid().ToString();

            // there we can use Url, Username and Password
            return Task.FromResult<SentSmsInfo>(new OddProviderSentSmsInfo
            {
                MsgId = lastSentMsgId,
                Status = MessageStatus.Sending // or MessageStatus.Failed
            });
        }
    }
}