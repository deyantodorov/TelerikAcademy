using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using T00.Common;

namespace T06.ExtractsAllSongsTitlesWithLinq
{
    /// <summary>
    /// 6. Rewrite the same using XDocument and LINQ query.
    /// </summary>
    public class ExtractsAllSongsTitlesWithLinq
    {
        private static void Main()
        {
            var allTitles = GetSongsTitles(Constants.FilePathForCatalogue);
            PrintResult(allTitles);
        }

        private static void PrintResult(List<string> allTitles)
        {
            if (allTitles.Any())
            {
                allTitles.ForEach(x => Console.WriteLine("Song title: {0}", x));
            }
            else
            {
                Console.WriteLine("No songs");
            }

            Console.WriteLine("Total songs: {0}", allTitles.Count);
        }

        private static List<string> GetSongsTitles(string path)
        {
            XDocument document = XDocument.Load(path);

            // Get songs titles and test if title isn't null
            var songs = (from song in document.Descendants("song")
                         let xElement = song.Element("title")
                         where xElement != null
                         select xElement.Value)
                           .ToList();

            return songs;
        }
    }
}
