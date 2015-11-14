namespace HW02.ConsumingWebServices
{
    /// <summary>
    /// Write a console application, which searches for news articles by given a query stringand a count of articles to retrieve.
    /// The application should ask the user for input and print the Titles and URLs of the articles. 
    /// For news articles search, use the Feedzilla API and use one of WebClient, HttpWebRequest or HttpClient
    /// 
    /// IMPORTANT: I found that Feedzilla is down by "some reasons", so I use Google search to provide relevant result by some topic. 
    /// I hope you will find it helpfull
    /// </summary>
    public class StartUp
    {
        private static void Main()
        {
           var googleSearch = new GoogleSearch();
            googleSearch.Start();
        }
    }
}
