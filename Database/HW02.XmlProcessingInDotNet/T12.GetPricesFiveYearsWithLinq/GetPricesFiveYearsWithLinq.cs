using System;
using System.Linq;
using System.Xml.Linq;
using T00.Common;

namespace T12.GetPricesFiveYearsWithLinq
{
    /// <summary>
    /// 12. Rewrite the previous using LINQ query.
    /// </summary>
    public class GetPricesFiveYearsWithLinq
    {
        private const string SaveFilePath = @"../../Albums.xml";

        private static void Main()
        {
            var xml = XDocument.Load(Constants.FilePathForCatalogue);

            var list = (from album in xml.Descendants("albums")
                let xElementYear = album.Element("year")
                where xElementYear != null && int.Parse(xElementYear.Value) < 2008
                let xElementName = album.Element("name")
                where xElementName != null
                let xElementPrice = album.Element("price")
                where xElementPrice != null
                select new
                {
                    Name = xElementName.Value,
                    Price = xElementPrice.Value
                })
                .ToList();

            if (!list.Any())
            {
                Console.WriteLine("No results");
                return;
            }

            var newXml = new XElement("albums");
            foreach (var item in list)
            {
                var album = new XElement("album");
                album.Add(new XElement("album", item.Name), new XElement("price", item.Price));

                newXml.Add(album);
            }

            newXml.Save(SaveFilePath);
            Console.WriteLine("Albums.xml is in project folder");
        }
    }
}
