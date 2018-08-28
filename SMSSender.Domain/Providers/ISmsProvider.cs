using System.Threading;
using System.Threading.Tasks;

namespace SMSSender.Domain.Providers
{
    public interface ISmsProvider
    {
        Task SendSms(string msg, CancellationToken cancellationToken);
    }
}