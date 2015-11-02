namespace ArtistSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using ArtistSystem.Data.Contracts;
    using ArtistSystem.Data.Repositories;
    using ArtistSystem.Models;

    public class ArtistSystemData : IArtistSystemData
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ArtistSystemData(DbContext context)
        {
            this.Context = context;
        }

        public DbContext Context { get; private set; }

        public IRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public IRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
        }

        public IRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }
        
        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                }
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
