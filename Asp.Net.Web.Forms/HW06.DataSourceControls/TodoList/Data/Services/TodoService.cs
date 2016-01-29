using System;
using System.Linq;
using TodoList.Data.Repositories;
using TodoList.Data.Services.Contracts;
using TodoList.Models;

namespace TodoList.Data.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> todos;

        public TodoService(IRepository<Todo> todos)
        {
            this.todos = todos;
        }

        public IQueryable<Todo> GetById(int id)
        {
            return this.todos.All().Where(x => x.Id == id);
        }

        public IQueryable<Todo> GetAll()
        {
            return this.todos.All().Where(x => (!x.IsRemoved)).OrderByDescending(x => x.Id);
        }

        public int Add(string title, string text, int categoryId)
        {
            var todo = new Todo()
            {
                Title = title,
                Text = text,
                CategoryId = categoryId,
                LastChange = DateTime.Now
            };

            this.todos.Add(todo);
            this.todos.SaveChanges();

            return todo.Id;
        }

        public void Update(Todo todo)
        {
            this.todos.Update(todo);
            this.todos.SaveChanges();
        }

        public void Remove(Todo todo)
        {
            todo.IsRemoved = true;

            this.todos.Update(todo);
            this.todos.SaveChanges();
        }
    }
}