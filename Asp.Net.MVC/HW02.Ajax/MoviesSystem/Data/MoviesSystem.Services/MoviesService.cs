using System.Linq;
using MoviesSystem.Data.Repositories;
using MoviesSystem.Models;
using MoviesSystem.Services.Contracts;

namespace MoviesSystem.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> movies;

        public MoviesService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetAll(int skip = 1, int take = 10)
        {
            return this.movies.All()
                .OrderByDescending(x => x.Id)
                .Skip(skip * take)
                .Take(take);
        }

        public int GetCount()
        {
            return this.movies.All().Count();
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void DeleteById(int id)
        {
            this.movies.Delete(id);
            this.movies.SaveChanges();
        }

        public bool Any(int id)
        {
            return this.movies.All().Any(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            this.movies.Update(movie);
            this.movies.SaveChanges();
        }

        public void Add(Movie movie)
        {
            this.movies.Add(movie);
            this.movies.SaveChanges();
        }

        public bool MaleRoleExist(string name, int age)
        {
            return this.movies.All().Any(x => x.LeadingMaleRole.Name == name && x.LeadingMaleRole.Age == age);
        }

        public int GetMaleRoleId(string name, int age)
        {
            return this.movies
                .All()
                .First(x => x.LeadingMaleRole.Name == name && x.LeadingMaleRole.Age == age)
                .Id;
        }

        public bool FemaleRoleExist(string name, int age)
        {
            return this.movies.All().Any(x => x.LeadingFemaleRole.Name == name && x.LeadingFemaleRole.Age == age);
        }

        public int GetFemaleRoleId(string name, int age)
        {
            return this.movies
                .All()
                .First(x => x.LeadingFemaleRole.Name == name && x.LeadingFemaleRole.Age == age)
                .Id;
        }
    }
}
