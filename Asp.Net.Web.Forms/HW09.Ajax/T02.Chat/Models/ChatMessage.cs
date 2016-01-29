using System;
using System.ComponentModel.DataAnnotations;

namespace T02.Chat.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
