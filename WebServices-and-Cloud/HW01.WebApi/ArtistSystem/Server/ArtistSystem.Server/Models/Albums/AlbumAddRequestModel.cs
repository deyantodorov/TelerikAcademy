namespace ArtistSystem.Server.Models.Albums
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Infrastructure.Mapping;

    public class AlbumAddRequestModel : IMapFrom<Album>
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Producer { get; set; }
    }
}
