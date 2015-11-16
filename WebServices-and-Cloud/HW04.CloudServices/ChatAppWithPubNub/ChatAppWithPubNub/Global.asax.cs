using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChatAppWithPubNub
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Clear WebForms ViewEngine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
