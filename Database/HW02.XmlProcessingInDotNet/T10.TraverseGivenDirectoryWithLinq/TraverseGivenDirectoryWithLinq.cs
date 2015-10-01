using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace T10.TraverseGivenDirectoryWithLinq
{
    /// <summary>
    /// 10. Rewrite the last exercises using XDocument, XElement and XAttribute.
    /// </summary>
    public class TraverseGivenDirectoryWithLinq
    {
        private const string DirectoryToTraverse = @"C:\Temp";
        private const string XmlSaveFilePath = @"../../Directory.xml";

        private static void Main()
        {
            var xml = new XElement("directory");
            var content = Traverse(new DirectoryInfo(DirectoryToTraverse));
            xml.Add(content);

            xml.Save(XmlSaveFilePath);
            Console.WriteLine("Directory.xml created in project folder.");
        }

        private static XElement Traverse(DirectoryInfo directory)
        {
            var dir = new XElement("dir", new XAttribute("name", directory.Name));

            foreach (var file in directory.GetFiles().Select(item => new XElement("file", new XAttribute("name", item.Name))))
            {
                dir.Add(file);
            }

            foreach (var subDirectory in directory.GetDirectories())
            {
                dir.Add(Traverse(subDirectory));
            }

            return dir;
        }
    }
}
