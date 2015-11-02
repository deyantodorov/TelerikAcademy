namespace ArtistSystem.Data.Contracts
{
    using System.Data.Entity;
    using ArtistSystem.Data.Repositories;
    using ArtistSystem.Models;

    public interface IArtistSystemData
    {
        DbContext Context { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        int SaveChanges();

        void Dispose();
    }
}
