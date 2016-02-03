using System.Web.Mvc;

namespace InformationalApplication.Areas.Forum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}