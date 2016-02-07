using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MoviesSystem.Models;

namespace MoviesSystem.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Actor> Actors { get; set; }

        public virtual IDbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
