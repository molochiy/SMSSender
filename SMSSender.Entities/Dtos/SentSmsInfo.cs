using SMSSender.Common.Enums;

namespace SMSSender.Entities.Dtos
{
    public class SentSmsInfo
    {
        public MessageStatus Status { get; set; }

        public string MsgId { get; set; }
    }
}
