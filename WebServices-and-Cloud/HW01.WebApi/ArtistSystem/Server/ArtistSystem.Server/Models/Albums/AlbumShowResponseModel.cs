namespace ArtistSystem.Server.Models.Albums
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Infrastructure.Mapping;
    using AutoMapper;

    public class AlbumShowResponseModel : IMapFrom<Album>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Producer { get; set; }

        public int NumberOfSongs { get; set; }

        public int NumberOfArtists { get; set; }
        
        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Album, AlbumShowResponseModel>()
                .ForMember(x => x.NumberOfSongs, opts => opts.MapFrom(s => s.Songs.Count))
                .ForMember(x => x.NumberOfArtists, opts => opts.MapFrom(a => a.Artists.Count));
        }
    }
}
