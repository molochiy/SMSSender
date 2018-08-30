using System;
using SMSSender.Common.Enums;

namespace SMSSender.Persistence.Entities
{
    public class MessageEntity: EntityBase
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Message { get; set; }

        public MessageStatus Status { get; set; }

        public string ExternalMessageId { get; set; }

        public DateTime? TimeOfSending { get; set; }
    }
}