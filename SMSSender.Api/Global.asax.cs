using System.Web.Http;

namespace SMSSender.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Configure);
        }
    }
}
