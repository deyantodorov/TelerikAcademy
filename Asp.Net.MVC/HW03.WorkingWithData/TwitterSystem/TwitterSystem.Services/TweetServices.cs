using System.Linq;
using TwitterSystem.Data.Repositories;
using TwitterSystem.Models;
using TwitterSystem.Services.Contracts;

namespace TwitterSystem.Services
{
    public class TweetServices : ITweetServices
    {
        private IRepository<Tweet> tweets;
        
        public TweetServices(IRepository<Tweet> tweets)
        {
            this.tweets = tweets;
        }

        public Tweet GetById(int id)
        {
            return this.tweets.GetById(id);
        }

        public IQueryable<Tweet> GetAllByUserId(string userId)
        {
            return this.tweets.All().Where(x => x.IsVisible && x.UserId == userId);
        }

        public IQueryable<Tweet> GetAll()
        {
            return this.tweets.All().Where(x => x.IsVisible);
        }

        public void Update(Tweet tweet)
        {
            this.tweets.Update(tweet);
            this.tweets.SaveChanges();
        }

        public void Add(Tweet tweet)
        {
            this.tweets.Add(tweet);
            this.tweets.SaveChanges();
        }
    }
}
