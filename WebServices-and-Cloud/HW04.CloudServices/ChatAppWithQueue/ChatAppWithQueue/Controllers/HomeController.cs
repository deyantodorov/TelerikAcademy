using System.Web.Mvc;

namespace ChatAppWithQueue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
