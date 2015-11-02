namespace ArtistSystemConsoleHttpClient
{
    using System;
    using ArtistSystemConsoleHttpClient.Commands;
    using ArtistSystemConsoleHttpClient.Factory;

    public class StartUp
    {
        private static void Main()
        {
            var commandFactory = new CommandFactory();

            var songCommand = commandFactory.GetCommand("songs");
            var artistCommand = commandFactory.GetCommand("artists");
            var albumCommand = commandFactory.GetCommand("albums");

            try
            {
                // TODO: Uncomment one by one to try HttpClient
                // Add 10 rendom values
                songCommand.Add();
                artistCommand.Add();
                albumCommand.Add();

                // Get songs by xml or json
                //songCommand.Get(ContentType.Xml);
                //songCommand.GetById(ContentType.Xml, 9);
                //artistCommand.GetById(ContentType.Xml, 9);
                //albumCommand.GetById(ContentType.Xml, 10);

                //songCommand.GetById(ContentType.Json, 9);
                //artistCommand.GetById(ContentType.Json, 9);
                //albumCommand.GetById(ContentType.Json, 10);

                // Update
                //songCommand.Update(10);
                //artistCommand.Update(10);
                //albumCommand.Update(10);

                // Delete
                //songCommand.Delete(9);
                //artistCommand.Delete(9);
                //albumCommand.Delete(9);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Did you run the server first with Sql Server started???");
                Console.WriteLine(ex);
            }
        }
    }
}
