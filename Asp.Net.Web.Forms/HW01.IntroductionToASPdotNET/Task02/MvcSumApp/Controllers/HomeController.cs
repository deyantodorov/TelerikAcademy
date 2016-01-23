using System.Web.Mvc;
using MvcSumApp.Models;

namespace MvcSumApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(decimal? totalSum, bool isValid = false)
        {
            var sum = new SumViewModel
            {
                FirstNumber = 0m,
                SecondNumber = 0m,
                TotalSum = totalSum ?? 0
            };
            
            this.ViewBag.IsValid = isValid;
            return this.View(sum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SumViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home", new { isValid = true });
            }

            model.TotalSum = model.FirstNumber + model.SecondNumber;

            return this.RedirectToAction("Index", "Home", new { totalSum = model.TotalSum, isValid = false });
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}