using System.Threading;
using System.Threading.Tasks;
using SMSSender.Entities.Models;

namespace SMSSender.Domain.Providers
{
    class OddSmsProvider : SmsProviderBase, ISmsProvider
    {
        protected override SmsFinalStatus GetFinalStatus()
        {
            throw new System.NotImplementedException();
        }

        protected override Task Send(string msg, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}