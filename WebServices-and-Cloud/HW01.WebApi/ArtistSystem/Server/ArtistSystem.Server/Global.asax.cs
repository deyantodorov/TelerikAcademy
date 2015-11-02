namespace ArtistSystem.Server
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using ArtistSystem.Common;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load(Constants.ServerAssemblyName));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DatabaseConfig.Initialize();
        }
    }
}