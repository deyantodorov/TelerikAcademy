namespace T03.FindWords.Trie
{
    using System.Collections.Generic;

    public class TrieNode
    {
        public TrieNode(char character, IDictionary<char, TrieNode> children, int wordCount, TrieNode parent)
        {
            this.Character = character;
            this.Children = children;
            this.WordCount = wordCount;
            this.Parent = parent;
        }

        public char Character { get; private set; }

        public IDictionary<char, TrieNode> Children { get; private set; }

        public int WordCount { get; set; }

        public bool IsWord
        {
            get { return this.WordCount > 0; }
        }

        public TrieNode Parent { get; set; }

        public override string ToString()
        {
            return this.Character.ToString();
        }

        public override int GetHashCode()
        {
            return this.Character.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TrieNode node = obj as TrieNode;
            return node != null && node.Character == this.Character;
        }
    }
}
