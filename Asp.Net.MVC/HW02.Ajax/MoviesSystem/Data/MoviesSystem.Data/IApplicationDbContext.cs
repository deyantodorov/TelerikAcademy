using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MoviesSystem.Models;

namespace MoviesSystem.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Actor> Actors { get; set; }

        IDbSet<Studio> Studios { get; set; }

        void Dispose();

        int SaveChanges();
    }
}