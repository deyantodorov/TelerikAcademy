using System.Linq;
using TodoList.Data.Repositories;
using TodoList.Data.Services.Contracts;
using TodoList.Models;

namespace TodoList.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories.All().Where(x => x.Id == id);
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().Where(x => !x.IsRemoved).OrderByDescending(x => x.Id);
        }

        public int Add(string name)
        {
            var category = new Category()
            {
                Name = name
            };

            this.categories.Add(category);
            this.categories.SaveChanges();

            return category.Id;
        }

        public int Update(Category category)
        {
            this.categories.Update(category);
            this.categories.SaveChanges();
            return category.Id;
        }

        public void Remove(Category category)
        {
            category.IsRemoved = true;

            this.categories.Update(category);
            this.categories.SaveChanges();
        }
    }
}