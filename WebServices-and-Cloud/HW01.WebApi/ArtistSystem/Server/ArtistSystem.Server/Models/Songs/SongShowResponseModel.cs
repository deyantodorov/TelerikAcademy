namespace ArtistSystem.Server.Models.Songs
{
    using ArtistSystem.Models;
    using ArtistSystem.Server.Infrastructure.Mapping;

    public class SongShowResponseModel : IMapFrom<Song>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public int Year { get; set; }

        public string Genre { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }
    }
}
