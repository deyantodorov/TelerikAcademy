using System.Web.Mvc;

namespace InformationalApplication.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}