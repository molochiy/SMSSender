using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using SMSSender.Persistence.Repositories;

namespace SMSSender.Persistence
{
    public static class PersistenceModule
    {
        public static void RegisterPersistenceModule(this IServiceCollection services)
        {
            InitializeDb(services);
            SetupRepositories(services);
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserOrdersRepository, UserOrdersRepository>();
        }

        private static void InitializeDb(IServiceCollection services)
        {
            Database.SetInitializer(new NullDatabaseInitializer<SmsSenderDb>());

            services.AddScoped<IDbProvider<ISmsSenderDb>, SmsSenderDbProvider>();
        }
    }
}
