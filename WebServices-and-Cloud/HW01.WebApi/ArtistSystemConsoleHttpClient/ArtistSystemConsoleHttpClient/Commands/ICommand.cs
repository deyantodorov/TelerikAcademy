namespace ArtistSystemConsoleHttpClient.Commands
{
    public interface ICommand
    {
        void Add();

        void Get(ContentType type);

        void GetById(ContentType type, int id);

        void Update(int id);

        void Delete(int id);
    }
}