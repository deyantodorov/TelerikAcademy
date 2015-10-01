using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using T00.Common;

namespace T03.ExtractArtistAndAlbumsWithXPath
{
    /// <summary>
    /// 3. Implement the previous (2) using XPath
    /// </summary>
    public class ExtractArtistAndAlbumsWithXPath
    {
        private static void Main()
        {
            var nodeList = GetNodeList(Constants.FilePathForCatalogue);

            var artists = GetArtists(nodeList);

            PrintArtists(artists);
        }

        private static void PrintArtists(SortedDictionary<string, int> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine($"Artist name: {artist.Key}, Number of albums: {artist.Value}");
            }
        }

        private static SortedDictionary<string, int> GetArtists(XmlNodeList rootNode)
        {
            var artists = new SortedDictionary<string, int>();

            if (rootNode == null)
            {
                throw new ArgumentNullException("rootNode" + "is empty");
            }

            foreach (var currentAuthor in from XmlNode node in rootNode
                                          select node.SelectSingleNode("artist") 
                                          into selectSingleNode where selectSingleNode != null
                                          select selectSingleNode.InnerText)
            {
                if (!artists.ContainsKey(currentAuthor))
                {
                    artists.Add(currentAuthor, 0);
                }

                artists[currentAuthor]++;
            }

            return artists;
        }


        private static XmlNodeList GetNodeList(string path)
        {
            var document = new XmlDocument();
            document.Load(path);

            var xPathQuery = "/catalog/albums";
            var nodeList = document.SelectNodes(xPathQuery);

            return nodeList;
        }
    }
}
