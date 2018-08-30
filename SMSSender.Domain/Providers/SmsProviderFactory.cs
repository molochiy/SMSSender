namespace SMSSender.Domain.Providers
{
    public class SmsProviderFactory : ISmsProviderFactory
    {
        public ISmsProvider CreateProvider(string phoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}