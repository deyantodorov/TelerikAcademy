using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwitterSystem.Services.Contracts;
using TwitterSystem.Web.Infrastructure.Mapping;
using TwitterSystem.Web.ViewModels.Tweets;

namespace TwitterSystem.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private ITweetServices tweets;

        public AdministrationController(ITweetServices tweets)
        {
            this.tweets = tweets;
        }

        public ActionResult Index()
        {
            var allTweets = this.tweets.GetAll().To<TweetAdminShortViewModel>().ToList();
            return View(allTweets);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = AutoMapperConfig
                .Configuration
                .CreateMapper()
                .Map<TweetEditViewModel>(this.tweets.GetById((int)id));

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(TweetEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var tweet = this.tweets.GetById(model.Id);
                tweet.Content = model.Content;

                this.tweets.Update(tweet);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Tweet not found");
            }

            var tweet = this.tweets.GetById((int) id);
            tweet.IsVisible = false;

            this.tweets.Update(tweet);
            
            return RedirectToAction("Index");
        }
    }
}