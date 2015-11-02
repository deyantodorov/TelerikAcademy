namespace ArtistSystem.Data
{
    using System.Data.Entity;
    using ArtistSystem.Models;

    public class ArtistSystemDbContext : DbContext
    {
        public ArtistSystemDbContext()
            : base("ArtistSystemConnection")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }
    }
}
