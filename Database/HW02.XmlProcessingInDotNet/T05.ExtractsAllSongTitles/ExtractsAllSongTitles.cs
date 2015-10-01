using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using T00.Common;

namespace T05.ExtractsAllSongTitles
{
    /// <summary>
    /// 5. Write a program, which using XmlReader extracts all song titles from catalog.xml
    /// </summary>
    public class ExtractsAllSongTitles
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
            var songs = new List<string>();

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        songs.Add(reader.ReadElementString());
                    }
                }
            }

            return songs;
        }
    }
}
