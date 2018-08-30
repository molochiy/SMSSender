using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SMSSender.Common.Exceptions;
using SMSSender.Domain.Providers;
using SMSSender.Entities.Dtos;
using SMSSender.Entities.Models;
using SMSSender.Persistence.Entities;
using SMSSender.Persistence.Repositories;

namespace SMSSender.Domain.Services
{
    public class SmsSenderService : ISmsSenderService
    {
        private readonly IUserOrdersRepository _userOrdersRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly (string StartWith, int Length) _validNumberInfo = ("0", 10);

        public SmsSenderService(IUserOrdersRepository userOrdersRepository, IMessageRepository messageRepository, ISmsProviderFactory smsProviderFactory)
        {
            _userOrdersRepository = userOrdersRepository;
            _messageRepository = messageRepository;
            _smsProviderFactory = smsProviderFactory;
        }

        public async Task<IEnumerable<SmsSendingStatus>> SendSms(string msg, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
        {
            var phoneNumbers = await GetRelevantPhoneNumbers(startDate, endDate, cancellationToken).ConfigureAwait(false);

            var tasks = phoneNumbers.Select(x => SendSms(msg, x, cancellationToken)).ToList();

            await Task.WhenAll(tasks).ConfigureAwait(false);

            return tasks.Select(x => x.Result);
        }

        public async Task UpdateSmsStatus(SmsFinalStatus finalStatus, CancellationToken cancellationToken)
        {
            MessageEntity message = await _messageRepository.Get()
                .Where(x => x.ExternalMessageId == finalStatus.ExternalMessageId)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (message == null)
            {
                throw new NotFoundException($"Could not find message with id {finalStatus.ExternalMessageId}");
            }

            message.Status = finalStatus.Status;

            if (finalStatus is OddProviderSmsFinalStatus oddProviderSmsFinalStatus)
            {
                message.TimeOfSending = oddProviderSmsFinalStatus.TimeOfSending;
            }

            await _messageRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private async Task<List<string>> GetRelevantPhoneNumbers(
            DateTime? startDate,
            DateTime? endDate,
            CancellationToken cancellationToken)
        {
            var query = _userOrdersRepository.Get()
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

            var phoneNumbers = await query.Select(x => x.UserMobileNumber).ToListAsync(cancellationToken).ConfigureAwait(false);

            return phoneNumbers.Where(x => x.All(char.IsDigit)).ToList();
        }

        private async Task<SmsSendingStatus> SendSms(string msg, string phoneNumber, CancellationToken cancellationToken)
        {
            SmsSendingStatus smsSendingStatus = new SmsSendingStatus
            {
                To = phoneNumber
            };

            var provider = _smsProviderFactory.CreateProvider(phoneNumber);

            try
            {
                var sentSmsInfo = await provider.SendSms(msg, cancellationToken).ConfigureAwait(false);

                var messageEntity = new MessageEntity
                {
                    Message = msg,
                    ExternalMessageId = sentSmsInfo.MsgId,
                    Status = sentSmsInfo.Status,
                    To = phoneNumber
                };

                if (sentSmsInfo is EvenProviderSentSmsInfo evenProviderSentSmsInfo)
                {
                    messageEntity.From = evenProviderSentSmsInfo.From;
                    messageEntity.To = evenProviderSentSmsInfo.To;
                }

                _messageRepository.Add(messageEntity);

                await _messageRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                smsSendingStatus.Status = sentSmsInfo.Status;
                smsSendingStatus.MsgId = sentSmsInfo.MsgId;
            }
            catch (Exception e)
            {
                smsSendingStatus.ExceptionMessage = e.Message;
            }

            return smsSendingStatus;
        }
    }
}