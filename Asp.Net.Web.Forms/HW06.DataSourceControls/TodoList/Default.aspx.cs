using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using TodoList.Data.Services;
using TodoList.Models;

namespace TodoList
{
    public partial class Default : Page
    {
        [Inject]
        public CategoryService CategoryService { get; set; }

        [Inject]
        public TodoService TodoService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Todo> GetTodos()
        {
            return this.TodoService.GetAll();
        }

        public void TodoUpdate(int id)
        {
            var item = this.TodoService.GetById(id).FirstOrDefault();

            if (item == null)
            {
                return;
            }

            item.LastChange = DateTime.Now;

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.TodoService.Update(item);
            }
        }

        public void TodoDelete(int id)
        {
            var item = this.TodoService.GetById(id).FirstOrDefault();
            this.TodoService.Remove(item);
        }

        public void TodoInsert()
        {
            var todo = new Todo { LastChange = DateTime.Now, CategoryId = 1 };

            this.TryUpdateModel(todo);

            if (this.ModelState.IsValid)
            {
                this.TodoService.Add(todo.Title, todo.Text, todo.CategoryId);
            }
        }

        public IQueryable<Category> GetCategories()
        {
            return this.CategoryService.GetAll();
        }

        public void CategoryDelete(int id)
        {
            var item = this.CategoryService.GetById(id).FirstOrDefault();
            this.CategoryService.Remove(item);
        }

        public void CategoryUpdate(int id)
        {
            var item = this.CategoryService.GetById(id).FirstOrDefault();

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.CategoryService.Update(item);
            }
        }

        public void CategoryInsert()
        {
            var category = new Category();
            this.TryUpdateModel(category);

            if (this.ModelState.IsValid)
            {
                this.CategoryService.Add(category.Name);
            }
        }

        protected void ListViewTodos_OnItemInserting(object sender, ListViewInsertEventArgs e)
        {
            var dropDownListCategories = (DropDownList)ListViewTodos.InsertItem.FindControl("DropDownListCategories");

            if (dropDownListCategories != null)
            {
                e.Values["Id"] = dropDownListCategories.SelectedValue;
            }
        }
    }
}