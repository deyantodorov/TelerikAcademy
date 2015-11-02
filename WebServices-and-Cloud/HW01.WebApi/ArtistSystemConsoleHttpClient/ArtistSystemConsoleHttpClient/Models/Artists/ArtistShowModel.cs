namespace ArtistSystemConsoleHttpClient.Models.Artists
{
    using System;

    public class ArtistShowModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Country { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
