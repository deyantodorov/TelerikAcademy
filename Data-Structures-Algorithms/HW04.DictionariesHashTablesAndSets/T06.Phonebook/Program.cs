namespace T06.Phonebook
{
    using System;
    using System.IO;
    using System.Text;

    public class Program
    {
        private static void Main()
        {
            var phonesPath = @"../../phones.txt";
            var commandsPath = @"../../commands.txt";

            var phonebook = ReadPhonesFromFile(phonesPath);
            ProcessSearchCommands(phonebook, commandsPath);
        }

        private static void ProcessSearchCommands(Phonebook phonebook, string path)
        {
            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var command = GetCommandParams(line);

                    if (command.Length == 2)
                    {
                        var nameTown = phonebook.FindByNameAndTownd(command[0], command[1]);

                        foreach (var contact in nameTown)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                    else if (command.Length == 1)
                    {
                        var name = phonebook.FindByName(command[0]);

                        foreach (var contact in name)
                        {
                            Console.WriteLine(contact);
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static string[] GetCommandParams(string line)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '(')
                {
                    while (line[i] != ')')
                    {
                        builder.Append(line[i]);
                        i++;
                    }

                    break;
                }
            }

            var searchParams = builder.ToString().Substring(1, builder.Length - 1).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return searchParams;
        }

        private static Phonebook ReadPhonesFromFile(string path)
        {
            var phonebook = new Phonebook();

            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var currentLine = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    var contact = new Contact(currentLine[0], currentLine[1], currentLine[2]);
                    
                    phonebook.Add(contact);

                    line = reader.ReadLine();
                }
            }

            return phonebook;
        }
    }
}
