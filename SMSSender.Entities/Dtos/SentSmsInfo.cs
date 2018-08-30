using SMSSender.Common.Enums;

namespace SMSSender.Entities.Dtos
{
    public class SentSmsInfo
    {
        public string From { get; set; }

        public string To { get; set; }

        public MessageStatus Status { get; set; }

        public string MsgId { get; set; }
    }
}
