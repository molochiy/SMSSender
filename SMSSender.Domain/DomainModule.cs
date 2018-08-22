using Microsoft.Extensions.DependencyInjection;
using SMSSender.Persistence;

namespace SMSSender.Domain
{
    public static class DomainModule
    {
        public static void RegisterDomainModule(this IServiceCollection services)
        {
            services.RegisterPersistenceModule();
        }
    }
}
