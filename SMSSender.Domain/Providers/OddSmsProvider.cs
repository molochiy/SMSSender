using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Common.Config;
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

        protected override SmsFinalStatus GetFinalStatus()
        {
            throw new System.NotImplementedException();
        }

        protected override Task<SentSmsInfo> Send(string msg, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}