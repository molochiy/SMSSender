using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace SMSSender.Api
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutofacModule>();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}