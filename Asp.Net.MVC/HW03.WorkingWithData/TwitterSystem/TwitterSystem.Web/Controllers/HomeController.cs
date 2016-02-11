using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TwitterSystem.Common;
using TwitterSystem.Models;
using TwitterSystem.Services.Contracts;
using TwitterSystem.Web.Infrastructure.Mapping;
using TwitterSystem.Web.ViewModels.Comments;
using TwitterSystem.Web.ViewModels.Tags;
using TwitterSystem.Web.ViewModels.Tweets;

namespace TwitterSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITagServices tagServices;
        private readonly ITweetServices tweetServices;

        public HomeController(ITagServices tagServices, ITweetServices tweetServices)
        {
            this.tagServices = tagServices;
            this.tweetServices = tweetServices;
        }

        public ActionResult Index()
        {
            List<TagViewModel> tags;

            if (this.HttpContext.Cache.Get("tags") == null)
            {
                tags = this.tagServices
                    .GetAll()
                    .To<TagViewModel>()
                    .ToList();

                this.HttpContext.Cache.Insert("tags", tags, null, DateTime.Now.AddMinutes(GlobalConstants.CacheTime), TimeSpan.Zero);
            }
            else
            {
                tags = (List<TagViewModel>)this.HttpContext.Cache.Get("tags");
            }

            return View(tags);
        }

        public ActionResult Tweets(int? tagId)
        {
            if (tagId == null)
            {
                return RedirectToAction("Index");
            }

            var cacheKey = "tag" + tagId;
            List<TweetShortViewModel> tweetsViewModels;

            if (this.HttpContext.Cache.Get(cacheKey) == null)
            {
                var tweets = this.tagServices.GetTweetsByTagId((int)tagId);

                if (tweets == null)
                {
                    return new HttpNotFoundResult("Tag not found");
                }

                tweetsViewModels = tweets.Select(tweet => new TweetShortViewModel()
                {
                    Id = tweet.Id,
                    Content = tweet.Content,
                    CommentsCount = tweet.Comments.Count()
                }).ToList();

                this.HttpContext.Cache.Insert(cacheKey, tweetsViewModels, null, DateTime.Now.AddMinutes(GlobalConstants.CacheTime), TimeSpan.Zero);
            }
            else
            {
                tweetsViewModels = (List<TweetShortViewModel>)this.HttpContext.Cache.Get(cacheKey);
            }

            return this.View(tweetsViewModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var tweet = this.tweetServices.GetById((int)id);

            if (tweet == null)
            {
                return new HttpNotFoundResult("Tweet not found");
            }

            var model = AutoMapperConfig.Configuration.CreateMapper().Map<TweetDetailViewModel>(tweet);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Details(CommentViewModel model)
        {
            // TODO: Implement later, but no time for now
            return this.View();
        }

        [Authorize]
        public ActionResult MyTweets()
        {
            var tweets = this.tweetServices.GetAllByUserId(this.User.Identity.GetUserId());
            var model = AutoMapperConfig.Configuration.CreateMapper().Map<List<TweetShortViewModel>>(tweets);

            return this.View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult PostTweet()
        {
            var model = new TweetInsertViewModel();
            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PostTweet(TweetInsertViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("PostTweet");
            }

            var tweet = new Tweet
            {
                CreatedOn = DateTime.Now,
                Content = model.Content,
                IsVisible = true,
                UserId = this.User.Identity.GetUserId(),
                
            };

            GetTags(model.Tags, tweet);

            this.tweetServices.Add(tweet);

            return RedirectToAction("MyTweets");
        }

        private void GetTags(string tags, Tweet tweet)
        {
            var allTags = tags.Split(' ');

            foreach (var item in allTags)
            {
                var newTag = new Tag();

                var founTag = this.tagServices.FindByName(item);

                if (founTag == null)
                {
                    newTag.Name = item;
                    newTag.IsVisible = true;
                }
                else
                {
                    newTag = founTag;
                    newTag.IsVisible = true;
                }

                tweet.Tags.Add(newTag);
            }
        }
    }
}