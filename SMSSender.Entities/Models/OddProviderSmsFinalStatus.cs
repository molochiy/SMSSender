using System;

namespace SMSSender.Entities.Models
{
    public class OddProviderSmsFinalStatus : SmsFinalStatus
    {
        public DateTime TimeOfSending { get; set; }
    }
}
