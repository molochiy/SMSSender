using System.Data.Entity;
using Autofac;
using SMSSender.Persistence.Repositories;

namespace SMSSender.Persistence
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            InitializeDb(builder);
            SetupRepositories(builder);
        }

        private static void SetupRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();
            builder.RegisterType<UserOrdersRepository>().As<IUserOrdersRepository>();
        }

        private static void InitializeDb(ContainerBuilder builder)
        {
            Database.SetInitializer(new NullDatabaseInitializer<SmsSenderDb>());

            builder.RegisterType<SmsSenderDbProvider>().As<IDbProvider<ISmsSenderDb>>();
        }
    }
}
