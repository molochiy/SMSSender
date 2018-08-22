using System;

namespace SMSSender.Persistence.Entities
{
    public class UserOrdersEntity : EntityBase
    {
        public string UserMobileNumber { get; set; }

        public DateTime OrderDateUtc { get; set; }
    }
}