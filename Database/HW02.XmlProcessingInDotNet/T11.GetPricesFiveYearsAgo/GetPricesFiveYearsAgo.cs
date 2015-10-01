using System;
using System.Xml;
using System.Xml.Linq;
using T00.Common;

namespace T11.GetPricesFiveYearsAgo
{
    /// <summary>
    /// 11. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use XPath query.
    /// </summary>
    public class GetPricesFiveYearsAgo
    {
        private const string SaveFilePath = @"../../Albums.xml";
        private const string XPathQuery = "/catalog/albums[year<2008]";

        private static void Main()
        {
            var xml = new XmlDocument();
            xml.Load(Constants.FilePathForCatalogue);
            
            var list = xml.SelectNodes(XPathQuery);

            if (list == null || list.Count <= 0)
            {
                Console.WriteLine("No results");
                return;
            }

            var newXml = new XElement("albums");

            foreach (XmlNode item in list)
            {
                XmlNode albumNode = item.SelectSingleNode("name");
                XmlNode priceNode = item.SelectSingleNode("price");

                if (albumNode == null || priceNode == null)
                {
                    continue;
                }

                var albumName = albumNode.InnerText;
                var price = priceNode.InnerText;

                var album = new XElement("album");
                album.Add(new XElement("album", albumName), new XElement("price", price));

                newXml.Add(album);
            }

            newXml.Save(SaveFilePath);

            Console.WriteLine("Albums.xml is in project folder");
        }
    }
}
