using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Persistence.Repositories;

namespace SMSSender.Domain.Services
{
    public class SmsSenderService : ISmsSenderService
    {
        private readonly IUserOrdersRepository _userOrdersRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly (string StartWith, int Length) _validNumberInfo = ("0", 10);

        public SmsSenderService(IUserOrdersRepository userOrdersRepository, IMessageRepository messageRepository)
        {
            _userOrdersRepository = userOrdersRepository;
            _messageRepository = messageRepository;
        }

        public async Task SendSms(string msg, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
        {
            var phoneNumbers = await GetRelevantPhoneNumbers(startDate, endDate, cancellationToken).ConfigureAwait(false);
        }

        private Task<List<string>> GetRelevantPhoneNumbers(
            DateTime? startDate,
            DateTime? endDate,
            CancellationToken cancellationToken)
        {
            var query = this._userOrdersRepository.Get()
                .Where(x => x.UserMobileNumber.StartsWith(_validNumberInfo.StartWith) &&
                            x.UserMobileNumber.Length == _validNumberInfo.Length);

            if (startDate.HasValue)
            {
                query = query.Where(x => x.OrderDateUtc >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(x => x.OrderDateUtc <= endDate);
            }

            return query.Select(x => x.UserMobileNumber).ToListAsync(cancellationToken);
        }
    }
}