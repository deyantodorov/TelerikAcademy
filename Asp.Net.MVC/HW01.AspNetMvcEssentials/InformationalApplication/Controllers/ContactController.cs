using System.Web.Mvc;

namespace InformationalApplication.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}