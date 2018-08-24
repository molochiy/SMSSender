using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace SMSSender.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<Domain.AutofacModule>();
        }
    }
}