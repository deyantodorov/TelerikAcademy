using System.Web.Mvc;
using System.Web.Routing;
using CustomConstraint.Infrastructure;

namespace CustomConstraint
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Admin",
                "Admin/{action}",
                new { controller = "Admin" },
                new { isLocal = new AdminConstraint() }
            );

        }
    }
}
