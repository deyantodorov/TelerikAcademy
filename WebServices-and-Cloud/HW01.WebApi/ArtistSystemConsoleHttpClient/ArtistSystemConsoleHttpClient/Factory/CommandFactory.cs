namespace ArtistSystemConsoleHttpClient.Factory
{
    using System;
    using System.Net.Http;
    using ArtistSystemConsoleHttpClient.Commands;
    using ArtistSystemConsoleHttpClient.HttpConsumers;

    public class CommandFactory
    {
        private const string ServerPath = "http://localhost:49274/";
        private const string ApiSongs = "api/songs";
        private const string ApiArtists = "api/artists";
        private const string ApiAlbums = "api/albums";
        private readonly IHttpConsumer consumer;

        public CommandFactory()
        {
            this.consumer = new HttpConsumer(new HttpClient(), ServerPath);
        }

        public ICommand GetCommand(string type)
        {
            switch (type)
            {
                case "songs":
                    return new SongCommand(this.consumer, ApiSongs);
                case "artists":
                    return new ArtistCommand(this.consumer, ApiArtists);
                case "albums":
                    return new AlbumCommand(this.consumer, ApiAlbums);
                default:
                    throw new ArgumentException("Unsupported command type");
            }
        }
    }
}