using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace T09.TraverseGivenDirectory
{
    /// <summary>
    /// 9. Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
    ///    Use tags<file> and<dir> with appropriate attributes.
    ///    For the generation of the XML document use the class XmlWriter.
    /// </summary>
    public class TraverseGivenDirectory
    {
        private const string DirectoryToTraverse = @"C:\Temp";
        private const string XmlSaveFilePath = @"../../Directory.xml";

        private static void Main()
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(XmlSaveFilePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("directory");

                Traverse(writer, new DirectoryInfo(DirectoryToTraverse));

                writer.WriteEndElement();
            }

            Console.WriteLine("Directory.xml created in project folder.");
        }

        private static void Traverse(XmlWriter writer, DirectoryInfo directory)
        {
            if (!directory.GetFiles().Any() && !directory.GetDirectories().Any())
            {
                return;
            }

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", directory.Name);

            foreach (var file in directory.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }
            
            foreach (var subDirectory in directory.GetDirectories())
            {
                Traverse(writer, subDirectory);
            }

            writer.WriteEndElement();
        }
    }
}
