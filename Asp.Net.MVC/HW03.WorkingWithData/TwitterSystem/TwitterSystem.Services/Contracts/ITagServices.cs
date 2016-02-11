using System.Collections.Generic;
using System.Linq;
using TwitterSystem.Models;

namespace TwitterSystem.Services.Contracts
{
    public interface ITagServices
    {
        IQueryable<Tag> GetAll();

        Tag GetById(int id);

        Tag FindByName(string name);

        void Add(Tag tag);

        ICollection<Tweet> GetTweetsByTagId(int id);
    }
}
