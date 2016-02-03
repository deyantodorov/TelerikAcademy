using System.Web.Mvc;

namespace InformationalApplication.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Forum_default",
                "Forum/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "InformationalApplication.Areas.Forum.Controllers" }
            );
        }
    }
}