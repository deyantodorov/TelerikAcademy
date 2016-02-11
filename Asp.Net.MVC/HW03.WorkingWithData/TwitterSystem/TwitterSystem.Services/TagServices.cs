using System.Collections.Generic;
using System.Linq;
using TwitterSystem.Data.Repositories;
using TwitterSystem.Models;
using TwitterSystem.Services.Contracts;

namespace TwitterSystem.Services
{
    public class TagServices : ITagServices
    {
        private readonly IRepository<Tag> tags;

        public TagServices(IRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> GetAll()
        {
            return this.tags.All();
        }

        public Tag GetById(int id)
        {
            return this.tags.GetById(id);
        }

        public Tag FindByName(string name)
        {
            return this.tags.All()
                .FirstOrDefault(t => t.Name.ToLower().Contains(name.ToLower()));
        }

        public void Add(Tag tag)
        {
            this.tags.Add(tag);
            this.tags.SaveChanges();
        }

        public ICollection<Tweet> GetTweetsByTagId(int id)
        {
            var tag = this.tags.GetById(id);
            var tweets = tag.Tweets.ToList();

            return tweets;
        }
    }
}