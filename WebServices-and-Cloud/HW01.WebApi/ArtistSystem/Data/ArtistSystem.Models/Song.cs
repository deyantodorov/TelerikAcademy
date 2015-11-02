namespace ArtistSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(150)]
        public string Genre { get; set; }

        public int? ArtistId { get; set; }

        public  virtual Artist Artist { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}