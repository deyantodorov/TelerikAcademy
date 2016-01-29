using System;
using System.Data.Entity.Migrations;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodoDbContext context)
        {
            var random = new Random();
            var id = random.Next(1, int.MaxValue - 1);

            var category = new Category()
            {
                Name = "Category" + id
            };

            context.Categories.Add(category);
            context.SaveChanges();
            
            var todo = new Todo()
            {
                Title = "Title" + id,
                Text = "Text" + id,
                CategoryId = category.Id,
                LastChange = DateTime.Now
            };

            context.Todos.Add(todo);
            context.SaveChanges();
        }
    }
}