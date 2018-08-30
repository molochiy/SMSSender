using SMSSender.Common.Enums;

namespace SMSSender.Entities.Dtos
{
    public class SmsSendingStatus
    {
        public string To { get; set; }

        public string MsgId { get; set; }

        public MessageStatus? Status { get; set; }

        public string ExceptionMessage { get; set; }
    }
}
