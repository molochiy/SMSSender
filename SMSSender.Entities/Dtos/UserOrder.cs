using System;

namespace SMSSender.Entities.Dtos
{
    public class UserOrder
    {
        public long Id { get; set; }

        public string UserMobileNumber { get; set; }

        public DateTime OrderDateUtc { get; set; }
    }
}
