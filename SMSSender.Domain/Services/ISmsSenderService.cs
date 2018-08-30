using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Entities.Dtos;
using SMSSender.Entities.Models;

namespace SMSSender.Domain.Services
{
    public interface ISmsSenderService
    {
        Task<IEnumerable<SmsSendingStatus>> SendSms(string msg, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken);

        Task UpdateSmsStatus(SmsFinalStatus finalStatus, CancellationToken cancellationToken);
    }
}