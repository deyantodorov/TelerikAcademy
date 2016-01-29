using System.Linq;
using TodoList.Models;

namespace TodoList.Data.Services.Contracts
{
    public interface ITodoService
    {
        IQueryable<Todo> GetById(int id);

        IQueryable<Todo> GetAll();

        int Add(string title, string text, int categoryId);

        void Update(Todo todo);

        void Remove(Todo todo);
    }
}
