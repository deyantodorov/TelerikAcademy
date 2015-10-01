using System;
using System.Collections.Generic;
using System.Xml;
using T00.Common;

namespace T08.ExtractAlbumsFromCatalog
{
    /// <summary>
    /// 8. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
    ///    in which stores in appropriate way the names of all albums and their authors.
    /// </summary>
    public class ExtractAlbumsFromCatalog
    {
        private const string NewFilePath = @"../../albums.xml";

        private static void Main()
        {
            var albumsWithAuthors = GetAlbumsAndAuthors(Constants.FilePathForCatalogue);
            WriteXml(albumsWithAuthors, NewFilePath);
            Console.WriteLine("Albums.xml created in project folder.");
        }

        private static void WriteXml(IEnumerable<Album> albums, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                foreach (Album album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Name);
                    writer.WriteElementString("artist", album.Artist);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private static IEnumerable<Album> GetAlbumsAndAuthors(string path)
        {
            var albums = new List<Album>();

            using (XmlReader reader = XmlReader.Create(path))
            {
                var albumName = string.Empty;
                var artistName = string.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                    {
                        albumName = reader.ReadElementString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "artist")
                    {
                        artistName = reader.ReadElementString();
                    }

                    if (albumName == string.Empty || artistName == string.Empty)
                    {
                        continue;
                    }

                    var album = new Album()
                    {
                        Name = albumName,
                        Artist = artistName,
                    };

                    albums.Add(album);

                    albumName = string.Empty;
                    artistName = string.Empty;
                }
            }

            return albums;
        }
    }
}
