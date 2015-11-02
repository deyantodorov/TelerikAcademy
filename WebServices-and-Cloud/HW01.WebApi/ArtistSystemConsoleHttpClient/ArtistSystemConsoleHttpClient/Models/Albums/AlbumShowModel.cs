namespace ArtistSystemConsoleHttpClient.Models.Albums
{
    using System;

    public class AlbumShowModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public string Producer { get; set; }

        public int NumberOfSongs { get; set; }

        public int NumberOfArtists { get; set; }
    }
}
