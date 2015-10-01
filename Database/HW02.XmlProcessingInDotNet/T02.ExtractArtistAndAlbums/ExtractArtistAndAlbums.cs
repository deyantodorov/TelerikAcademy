using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using T00.Common;

namespace T02.ExtractArtistAndAlbums
{
    /// <summary>
    /// 2. Write program that extracts all different artists which are found in the catalog.xml.
    ///    - For each author you should print the number of albums in the catalogue.
    ///    - Use the DOM parser and a hash-table.
    /// </summary>
    public class ExtractArtistAndAlbums
    {
        private static void Main()
        {
            var rootNode = GetRootNodeXmlDocument(Constants.FilePathForCatalogue);
            var artists = GetArtists(rootNode);

            PrintArtists(artists);
        }

        private static void PrintArtists(SortedDictionary<string, int> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist name: {0}, Number of albums: {1}", artist.Key, artist.Value);
            }
        }

        private static SortedDictionary<string, int> GetArtists(XmlNode rootNode)
        {
            var artists = new SortedDictionary<string, int>();

            if (rootNode == null)
            {
                throw new ArgumentNullException("rootNode" + "is empty");
            }

            foreach (var artistName in from XmlNode node in rootNode.ChildNodes
                                       select node["artist"] into xmlElement
                                       where xmlElement != null
                                       select xmlElement.InnerText)
            {
                if (artists.ContainsKey(artistName))
                {
                    artists[artistName]++;
                }
                else
                {
                    artists.Add(artistName, 1);
                }
            }

            return artists;
        }

        private static XmlElement GetRootNodeXmlDocument(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            return doc.DocumentElement;
        }
    }
}
