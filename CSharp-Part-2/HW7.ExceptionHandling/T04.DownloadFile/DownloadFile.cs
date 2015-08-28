namespace T04.DownloadFile
{
    using System;
    using System.Net;

    /// <summary>
    /// 4. Write a program that downloads a file from Internet (e.g. http://telerikacademy.com/Content/Images/news-img01.png) and stores it the current directory. 
    ///    Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.
    /// </summary>
    public class DownloadFile
    {
        public static void Dowloader(string filePath)
        {
            WebClient myWebClient = new WebClient();

            try
            {
                int index = filePath.LastIndexOf("/");

                string remoteUri = filePath.Substring(0, index + 1);
                string fileName = filePath.Substring(index + 1);
                string myWebStringResource = null;

                myWebStringResource = remoteUri + fileName;
                Console.WriteLine("Downloading file {0} from {1}", fileName, myWebStringResource);
                myWebClient.DownloadFile(myWebStringResource, fileName);
                Console.WriteLine("Download compleated");
                Console.WriteLine("File is in:\n{0}", Environment.CurrentDirectory);
            }
            catch (WebException)
            {
                Console.WriteLine("An error occurred while downloading data");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("An error occurred while downloading data");
            }
            finally
            {
                myWebClient.Dispose();
            }
        }

        private static void Main()
        {
            Console.Write("Enter file path: ");
            Dowloader(Console.ReadLine());
        }
    }
}
