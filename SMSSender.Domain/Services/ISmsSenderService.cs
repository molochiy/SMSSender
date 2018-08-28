using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMSSender.Domain.Services
{
    public interface ISmsSenderService
    {
        Task SendSms(string msg, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken);
    }
}