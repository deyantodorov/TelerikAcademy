namespace ArtistSystemConsoleHttpClient.Models.Albums
{
    using System;

    public class AlbumAddModel
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public string Producer { get; set; }
    }
}
