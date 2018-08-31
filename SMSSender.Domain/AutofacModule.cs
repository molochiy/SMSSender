using Autofac;
using SMSSender.Domain.Providers;
using SMSSender.Domain.Services;

namespace SMSSender.Domain
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserOrdersService>().As<IUserOrdersService>();
            builder.RegisterType<SmsSenderService>().As<ISmsSenderService>();
            builder.RegisterType<SmsProviderFactory>().As<ISmsProviderFactory>();
            builder.RegisterModule<Persistence.AutofacModule>();
        }
    }
}
