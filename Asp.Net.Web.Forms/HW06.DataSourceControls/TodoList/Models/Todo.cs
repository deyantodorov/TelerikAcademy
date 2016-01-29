using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Title { get; set; }

        [MinLength(2)]
        [MaxLength(2500)]
        public string Text { get; set; }

        public DateTime LastChange { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsRemoved { get; set; }
    }
}