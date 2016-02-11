using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TwitterSystem.Models;

namespace TwitterSystem.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Tag> Tags { get; set; }
        
        void Dispose();

        int SaveChanges();
    }
}
