namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2500)] // Increase if need more, not by condition, but better then max
        public string Content { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime? SeeingDate { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User User { get; set; }

        // Todo: Each message has friendship ???
        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }
    }
}
