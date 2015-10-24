namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
