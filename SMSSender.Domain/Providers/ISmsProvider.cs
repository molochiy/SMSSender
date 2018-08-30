using System.Threading;
using System.Threading.Tasks;
using SMSSender.Entities.Dtos;

namespace SMSSender.Domain.Providers
{
    public interface ISmsProvider
    {
        Task<SentSmsInfo> SendSms(string msg, CancellationToken cancellationToken);
    }
}