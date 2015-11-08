namespace T03.FindWords.Trie
{
    using System.Collections.Generic;
    using System.Text;

    public class Trie : ITrie
    {
        private TrieNode root;

        public Trie(TrieNode root)
        {
            this.root = root;
        }

        public void Add(string word)
        {
            this.AddWord(this.root, word.ToCharArray());
        }

        public void Remove(string word)
        {
            var trieNode = this.GetTrieNode(word);
            if (trieNode != null && trieNode.IsWord)
            {
                trieNode.WordCount = 0;
                this.RemoveNode(trieNode);
            }
        }

        public ICollection<string> GetWords()
        {
            var words = new List<string>();
            var buffer = new StringBuilder();
            this.GetWords(this.root, words, buffer);
            return words;
        }

        public ICollection<string> GetWords(string prefix)
        {
            ICollection<string> words;
            if (string.IsNullOrEmpty(prefix))
            {
                words = this.GetWords();
            }
            else
            {
                var trieNode = this.GetTrieNode(prefix);

                // Empty list if no prefix match
                words = new List<string>();
                if (trieNode != null)
                {
                    var buffer = new StringBuilder();
                    buffer.Append(prefix);
                    this.GetWords(trieNode, words, buffer);
                }
            }

            return words;
        }

        public bool HasWord(string word)
        {
            var trieNode = this.GetTrieNode(word);
            return trieNode != null && trieNode.IsWord;
        }

        public int WordCount(string word)
        {
            var trieNode = this.GetTrieNode(word);
            return trieNode == null ? 0 : trieNode.WordCount;
        }

        /// <summary>
        /// Get the equivalent TrieNode in the Trie for given prefix. 
        /// If prefix not present, then return null.
        /// </summary>
        private TrieNode GetTrieNode(string prefix)
        {
            var trieNode = this.root;
            foreach (var prefixChar in prefix.ToCharArray())
            {
                trieNode.Children.TryGetValue(prefixChar, out trieNode);
                if (trieNode == null)
                {
                    break;
                }
            }

            return trieNode;
        }

        /// <summary>
        /// Method to add word. Gets the first char of the word, 
        /// creates the child TrieNode if null, and recurses with the first
        /// char removed from the word. If the word length is 0, return.
        /// </summary>
        private void AddWord(TrieNode trieNode, char[] word)
        {
            while (true)
            {
                if (word.Length == 0)
                {
                    trieNode.WordCount++;
                }
                else
                {
                    var firstChar = FirstChar(word);
                    TrieNode child;
                    trieNode.Children.TryGetValue(firstChar, out child);

                    if (child == null)
                    {
                        child = GetTrieNode(firstChar, trieNode);
                        trieNode.Children[firstChar] = child;
                    }

                    var characterRemoved = FirstCharRemoved(word);
                    trieNode = child;
                    word = characterRemoved;
                    continue;
                }
                break;
            }
        }

        /// <summary>
        /// Recursive method to get all the words starting from given TrieNode.
        /// </summary>
        private void GetWords(TrieNode trieNode, ICollection<string> words, StringBuilder buffer)
        {
            if (trieNode.IsWord)
            {
                words.Add(buffer.ToString());
            }

            foreach (var child in trieNode.Children.Values)
            {
                buffer.Append(child.Character);
                this.GetWords(child, words, buffer);

                // Remove recent character
                buffer.Length--;
            }
        }

        /// <summary>
        /// Method to remove word. Remove only if node does not 
        /// have children and is not a word node and has a parent node.
        /// </summary>
        private void RemoveNode(TrieNode trieNode)
        {
            while (true)
            {
                // 1. should not have any children
                // 2. should not be a word
                // 3. do not remove root node
                if (trieNode.Children.Count == 0 && !trieNode.IsWord && !Equals(trieNode, this.root))
                {
                    var parent = trieNode.Parent;
                    trieNode.Parent.Children.Remove(trieNode.Character);
                    trieNode.Parent = null;
                    trieNode = parent;
                    continue;
                }

                break;
            }
        }

        /// <summary>
        /// Gets the word with the first character removed.
        /// </summary>
        private static char[] FirstCharRemoved(char[] word)
        {
            char[] cRemoved = null;
            if (word.Length > 0)
            {
                cRemoved = new char[word.Length - 1];
                for (var i = 1; i < word.Length; i++)
                {
                    cRemoved[i - 1] = word[i];
                }
            }

            return cRemoved;
        }

        /// <summary>
        /// Gets the first char of the word.
        /// </summary>
        private static char FirstChar(char[] word)
        {
            return word[0];
        }

        /// <summary>
        /// Get a new TrieNode instance.
        /// </summary>
        /// <param name="character">Character of the TrieNode.</param>
        private static TrieNode GetTrieNode(char character, TrieNode parent)
        {
            return new TrieNode(character, new Dictionary<char, TrieNode>(), 0, parent);
        }
    }
}
