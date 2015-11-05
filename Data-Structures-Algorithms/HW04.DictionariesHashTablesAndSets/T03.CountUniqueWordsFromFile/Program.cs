namespace T03.CountUniqueWordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 3. Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. 
    ///    The result words should be ordered by their number of occurrences in the text. Example:
    ///    This is the TEXT.Text, text, text – THIS TEXT! Is this the text?
    ///    is -> 2
    ///    the -> 2
    ///    this -> 3
    ///    text -> 6
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var filePath = @"../../words.txt";
            var words = GetUniqueWords(filePath);

            foreach (var word in words.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }

        private static SortedDictionary<string, int> GetUniqueWords(string filePath)
        {
            var words = new SortedDictionary<string, int>();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var currentLine = line.ToLower().Split(new[] { ' ', '.', ',', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in currentLine)
                    {
                        if (!words.ContainsKey(word))
                        {
                            words.Add(word, 1);
                        }
                        else
                        {
                            words[word] += 1;
                        }
                    }

                    line = reader.ReadLine();
                }
            }



            return words;
        }
    }
}
