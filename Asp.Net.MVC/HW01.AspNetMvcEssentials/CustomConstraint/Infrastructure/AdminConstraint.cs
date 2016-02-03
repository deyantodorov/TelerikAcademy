using System.Web;
using System.Web.Routing;

namespace CustomConstraint.Infrastructure
{
    public class AdminConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext, 
            Route route, 
            string parameterName, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            return httpContext.Request.Path.ToLower().Contains("admin");
        }
    }
}