using System.Data.Entity;
using TodoList.Migrations;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoDbContext : DbContext, ITodoDbContext
    {
        public TodoDbContext()
            : base("TodoDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoDbContext, Configuration>());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Todo> Todos { get; set; }
    }
}