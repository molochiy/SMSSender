using Autofac;
using SMSSender.Domain.Services;

namespace SMSSender.Domain
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserOrdersService>().As<IUserOrdersService>();
            builder.RegisterModule<Persistence.AutofacModule>();
        }
    }
}
