using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Common.Config;
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