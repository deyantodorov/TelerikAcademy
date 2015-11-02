namespace ArtistSystem.Server.Models.Artists
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Infrastructure.Mapping;

    public class ArtistAddRequestModel : IMapFrom<Artist>
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Country { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
