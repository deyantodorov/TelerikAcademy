using System.Linq;
using TwitterSystem.Models;

namespace TwitterSystem.Services.Contracts
{
    public interface ITweetServices
    {
        Tweet GetById(int id);

        IQueryable<Tweet> GetAllByUserId(string userId);

        IQueryable<Tweet> GetAll();

        void Update(Tweet tweet);

        void Add(Tweet tweet);
    }
}