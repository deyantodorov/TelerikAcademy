using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace T07.CreateXmlFromTextFile
{
    /// <summary>
    /// 7. In a text file we are given the name, address and phone number of given person (each at a single line).
    ///    Write a program, which creates new XML document, which contains these data in structured XML format.
    /// </summary>
    public class CreateXmlFromTextFile
    {
        private const string SourFilePath = @"../../persons.csv";
        private const string ResultFilePath = @"../../persons.xml";

        private static void Main()
        {
            var persons = ReadFile(SourFilePath);
            WriteFile(persons, ResultFilePath);
            Console.WriteLine("persons.xml created in current project file");
        }

        private static void WriteFile(List<Person> persons, string path)
        {
            XElement xml = new XElement("persons");

            foreach (Person person in persons)
            {
                xml.Add(new XElement("person",
                    new XElement("name", person.Name.Trim()),
                    new XElement("address", person.Address.Trim()),
                    new XElement("phone", person.Phone.Trim())
                    ));
            }

            xml.Save(path);
        }

        private static List<Person> ReadFile(string path)
        {
            var persons = new List<Person>();

            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var currentLine = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var person = new Person()
                    {
                        Name = currentLine[0],
                        Address = currentLine[1] + ", " + currentLine[2],
                        Phone = currentLine[3],
                    };

                    persons.Add(person);

                    line = reader.ReadLine();
                }
            }

            return persons;
        }
    }
}
