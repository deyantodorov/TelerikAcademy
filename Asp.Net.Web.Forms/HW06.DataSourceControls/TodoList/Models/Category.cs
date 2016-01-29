using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Category
    {
        private ICollection<Todo> todos;

        public Category()
        {
            this.todos = new HashSet<Todo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Todo> Todos
        {
            get { return this.todos; }
            set { this.todos = value; }
        }

        public bool IsRemoved { get; set; }
    }
}