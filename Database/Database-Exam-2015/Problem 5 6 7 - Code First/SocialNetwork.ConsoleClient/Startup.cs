namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Linq;
    using SocialNetwork.ConsoleClient.Searcher;
    using SocialNetwork.Data;

    public class Startup
    {
        public static void Main()
        {
            // Not time to debug
            //var xmlImporter = new XmlImporter();
            //xmlImporter.Execute();

            var socialNetworkService = new SocialNetworkService();
            DataSearcher.Search(socialNetworkService);

            //var data = new SocialNetworkDbContext();
            //Console.WriteLine(data.Users.Count());
        }
    }
}
