using SMSSender.Common.Enums;

namespace SMSSender.Entities.Models
{
    public class SmsFinalStatus
    {
        public string ExternalMessageId { get; set; }

        public MessageStatus Status { get; set; }
    }
}
