using System;

namespace SMSSender.Domain.Dtos
{
    public class UserOrder
    {
        public long Id { get; set; }

        public string UserMobileNumber { get; set; }

        public DateTime OrderDateUtc { get; set; }
    }
}
