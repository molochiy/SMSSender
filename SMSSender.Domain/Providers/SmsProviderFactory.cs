using System.Linq;

namespace SMSSender.Domain.Providers
{
    public class SmsProviderFactory : ISmsProviderFactory
    {
        public ISmsProvider CreateProvider(string phoneNumber)
        {
            var phoneNumberSum = phoneNumber.ToCharArray().Select(x => (int) char.GetNumericValue(x)).Sum();

            if (phoneNumberSum % 2 == 0)
            {
                return new EvenSmsProvider(phoneNumber);
            }

            return new OddSmsProvider(phoneNumber);
        }
    }
}