namespace SMSSender.Domain.Providers
{
    public interface ISmsProviderFactory
    {
        ISmsProvider CreateProvider(string phoneNumber);
    }
}