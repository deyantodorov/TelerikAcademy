using System.Linq;
using TodoList.Models;

namespace TodoList.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetById(int id);

        IQueryable<Category> GetAll();

        int Add(string name);

        int Update(Category category);

        void Remove(Category category);
    }
}
