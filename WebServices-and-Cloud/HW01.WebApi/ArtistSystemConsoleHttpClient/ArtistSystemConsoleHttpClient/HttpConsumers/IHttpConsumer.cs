namespace ArtistSystemConsoleHttpClient.HttpConsumers
{
    public interface IHttpConsumer
    {
        string Get(string uri, string header = "application/json");

        string Post(string uri, string content, string header = "application/json");

        string Put(string uri, string content, string header = "application/json");

        string Delete(string uri);
    }
}