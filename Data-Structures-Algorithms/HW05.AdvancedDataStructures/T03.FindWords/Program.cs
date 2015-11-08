namespace T03.FindWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using T03.FindWords.Trie;

    /// <summary>
    /// 3. Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
    ///    Print how many times each word occurs in the text.
    ///    Hint: you may find a C# trie in Internet.
    /// </summary>
    public class Program
    {
        private const string TextFile = @"../../bigFile.txt";
        private const string WordsFile = @"../../words.txt";

        private static void Main()
        {
            var start = DateTime.Now;

            var trie = BuildTreeFromFile(TextFile);
            var searchList = ReadSearchWords(WordsFile);
            var searchWords = searchList.ToDictionary(w => w, w => trie.WordCount(w));

            Console.WriteLine("Time for read 107 mb and 200 words: " + (DateTime.Now - start));

            start = DateTime.Now;
            foreach (var word in searchWords)
            {
                Console.WriteLine(word.Key + ": " + word.Value);
            }

            Console.WriteLine("Time for search on 200 words: " + (DateTime.Now - start));
        }

        private static List<string> ReadSearchWords(string wordsFile)
        {
            var result = new List<string>();
            var reader = new StreamReader(wordsFile);

            using (reader)
            {
                foreach (var word in Words(reader))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        private static ITrie BuildTreeFromFile(string file)
        {
            var trie = new Trie.Trie(new TrieNode(' ', new Dictionary<char, TrieNode>(), 0, null));
            int totalWords = 0;

            var reader = new StreamReader(file);

            using (reader)
            {
                foreach (var word in Words(reader))
                {
                    trie.Add(word);
                    totalWords++;
                }
            }

            return trie;
        }

        private static IEnumerable<string> Words(TextReader reader)
        {
            bool inWord = false;
            var sb = new StringBuilder();

            int read;

            while ((read = reader.Read()) != -1)
            {
                char ch = (char)read;
                if (char.IsLetter(ch) != inWord)
                {
                    inWord = !inWord;
                    if (!inWord)
                    {
                        yield return sb.ToString();
                        sb.Length = 0;
                    }
                }

                if (inWord)
                {
                    sb.Append(ch);
                }
            }

            if (inWord)
            {
                yield return sb.ToString();
            }
        }
    }
}
