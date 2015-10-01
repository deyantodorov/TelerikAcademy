using System;
using System.Xml.Linq;
using System.Xml.Schema;
using T00.Common;

namespace T16.ValidateCatalog
{
    public class ValidateCatalog
    {
        private static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, @"../../catalogue.xsd");

            var validXml = XDocument.Load(Constants.FilePathForCatalogue);
            var invalidXml = XDocument.Load(Constants.FilePathForIncorrectCatalogue);

            ValidateXml(validXml, schema, "catalogue.xml");
            ValidateXml(invalidXml, schema, "incorrectCatalogue.xml");
        }

        private static void ValidateXml(XDocument doc, XmlSchemaSet schema, string file)
        {
            doc.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine($"{file} - {ev.Message}");
            });
        }
    }
}
