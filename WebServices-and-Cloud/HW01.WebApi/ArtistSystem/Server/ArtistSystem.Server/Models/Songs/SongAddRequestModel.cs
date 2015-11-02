namespace ArtistSystem.Server.Models.Songs
{
    using System.ComponentModel.DataAnnotations;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Infrastructure.Mapping;

    public class SongAddRequestModel : IMapFrom<Song>
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Genre { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Range(0, 9999)]
        public int Year { get; set; }
    }
}
