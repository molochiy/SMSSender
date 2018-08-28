using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMSSender.Domain.Providers
{
    public abstract class SmsProviderBase
    {
        public Task SendSms(string msg, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
