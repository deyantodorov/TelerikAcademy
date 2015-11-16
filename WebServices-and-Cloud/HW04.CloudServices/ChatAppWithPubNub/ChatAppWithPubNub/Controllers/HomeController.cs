using System.Web.Mvc;

namespace ChatAppWithPubNub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
