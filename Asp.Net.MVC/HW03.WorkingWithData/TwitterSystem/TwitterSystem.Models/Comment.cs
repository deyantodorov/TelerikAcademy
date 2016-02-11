using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsVisible { get; set; }

        [Required]
        public int TweetId { get; set; }

        [ForeignKey("TweetId")]
        public virtual Tweet Tweet { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
