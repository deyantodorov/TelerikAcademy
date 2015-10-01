using System;
using System.Globalization;
using System.Xml;
using T00.Common;

namespace T04.DeleteHighPriceCatalogs
{
    /// <summary>
    /// 4. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
    /// </summary>
    public class DeleteHighPriceCatalogs
    {
        private const string NewFilePath = @"../../../catalog-with-price-less-than-twenty.xml";

        private static void Main()
        {
            var doc = new XmlDocument();
            doc.Load(Constants.FilePathForCatalogue);

            RemoveAlbumsWithPriceHigherThenTwenty(doc);
        }

        private static void RemoveAlbumsWithPriceHigherThenTwenty(XmlDocument document)
        {
            var rootNode = document.DocumentElement;

            if (rootNode != null)
            {
                foreach (XmlNode element in rootNode.ChildNodes)
                {
                    decimal price = 0.00m;

                    XmlElement xmlElement = element["price"];
                    bool isCorrectPrice = xmlElement != null && decimal.TryParse(xmlElement.InnerText, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out price);

                    if (isCorrectPrice && price > 20.00m)
                    {
                        element.RemoveAll();
                    }
                }
            }

            document.Save(NewFilePath);
            Console.WriteLine("Document saved. See in root solution folder.");
        }
    }
}
