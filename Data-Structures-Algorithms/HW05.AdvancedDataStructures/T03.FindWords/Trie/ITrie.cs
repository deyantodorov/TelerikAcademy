namespace T03.FindWords.Trie
{
    using System.Collections.Generic;

    public interface ITrie
    {
        void Add(string word);

        void Remove(string word);

        ICollection<string> GetWords();

        ICollection<string> GetWords(string prefix);

        bool HasWord(string word);

        int WordCount(string word);
    }
}