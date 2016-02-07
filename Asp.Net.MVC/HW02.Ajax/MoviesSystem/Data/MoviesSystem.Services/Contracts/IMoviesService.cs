using System.Linq;
using MoviesSystem.Models;

namespace MoviesSystem.Services.Contracts
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAll(int skip = 1, int take = 10);

        int GetCount();

        Movie GetById(int id);

        void DeleteById(int id);

        bool Any(int id);

        void Update(Movie movie);

        void Add(Movie movie);

        bool MaleRoleExist(string name, int age);

        int GetMaleRoleId(string name, int age);

        bool FemaleRoleExist(string name, int age);

        int GetFemaleRoleId(string name, int age);
    }
}