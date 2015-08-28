namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 6.* Binary search tree
    ///             Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". 
    ///             It is not necessary to keep the tree balanced.
    ///             Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode() and the operators for comparison == and !=.
    ///             Add and implement the ICloneable interface for deep copy of the tree.
    ///             Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.
    /// </summary>
    public class BinarySearchTree<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, ICloneable where TKey : IComparable<TKey>
    {
        private TreeNode root;

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();
                this.InorderTreeWalk(this.root, x => keys.Add(x.Key));
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                this.InorderTreeWalk(this.root, x => values.Add(x.Value));
                return values;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                TreeNode searchResult = this.Search(this.root, key);
                if (searchResult == null)
                {
                    throw new KeyNotFoundException();
                }

                return searchResult.Value;
            }

            set
            {
                TreeNode searchResult = this.Search(this.root, key);
                if (searchResult == null)
                {
                    throw new KeyNotFoundException();
                }

                searchResult.Value = value;
            }
        }

        public static bool operator ==(BinarySearchTree<TKey, TValue> first, BinarySearchTree<TKey, TValue> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BinarySearchTree<TKey, TValue> first, BinarySearchTree<TKey, TValue> second)
        {
            return !(first == second);
        }

        public void Add(TKey key, TValue value)
        {
            TreeNode newNode = new TreeNode(key, value, null, null, null);
            this.Insert(newNode);
        }

        public bool Remove(TKey key)
        {
            TreeNode node = this.Search(this.root, key);
            if (node == null)
            {
                return false;
            }

            this.Delete(node);
            return true;
        }

        public void Clear()
        {
            this.root = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.InorderTreeWalk(this.root, x => sb.AppendFormat("[Key: {0}; Value: {1}] ", x.Key, x.Value));
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            this.InorderTreeWalk(this.root, x => hash ^= x.GetHashCode());
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BinarySearchTree<TKey, TValue> tree = obj as BinarySearchTree<TKey, TValue>;
            if ((object)tree == null)
            {
                return false;
            }

            ICollection<TKey> thisKeys = this.Keys;
            ICollection<TKey> otherKeys = tree.Keys;

            if (thisKeys.Count != otherKeys.Count)
            {
                return false;
            }

            for (int i = 0; i < thisKeys.Count; i++)
            {
                if (thisKeys.ElementAt(i).CompareTo(otherKeys.ElementAt(i)) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            IList<KeyValuePair<TKey, TValue>> elems = new List<KeyValuePair<TKey, TValue>>();
            this.InorderTreeWalk(this.root, x => elems.Add(new KeyValuePair<TKey, TValue>(x.Key, x.Value)));

            foreach (var elem in elems)
            {
                yield return elem;
            }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public BinarySearchTree<TKey, TValue> Clone()
        {
            BinarySearchTree<TKey, TValue> newTree = new BinarySearchTree<TKey, TValue>();
            this.PreorderTreeWalk(this.root, x => newTree.Add(x.Key, x.Value));
            return newTree;
        }

        private void Insert(TreeNode newNode)
        {
            TreeNode parentNode = null;
            TreeNode currentNode = this.root;

            while (currentNode != null)
            {
                parentNode = currentNode;
                if (newNode.Key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            newNode.Parent = parentNode;

            if (parentNode == null)
            {
                this.root = newNode;
            }
            else if (newNode.Key.CompareTo(parentNode.Key) < 0)
            {
                parentNode.Left = newNode;
            }
            else if (newNode.Key.CompareTo(parentNode.Key) > 0)
            {
                parentNode.Right = newNode;
            }
            else
            {
                parentNode.Value = newNode.Value;
            }
        }

        private void Delete(TreeNode node)
        {
            if (node.Left == null)
            {
                this.Transplant(node, node.Right);
            }
            else if (node.Right == null)
            {
                this.Transplant(node, node.Left);
            }
            else
            {
                TreeNode y = this.Minimum(node.Right);
                if (!y.Parent.Equals(node))
                {
                    this.Transplant(y, y.Right);
                    y.Right = node.Right;
                    y.Right.Parent = y;
                }

                this.Transplant(node, y);
                y.Left = node.Left;
                y.Left.Parent = y;
            }
        }

        private void Transplant(TreeNode u, TreeNode v)
        {
            if (u.Parent == null)
            {
                this.root = v;
            }
            else if (u.Equals(u.Parent.Left))
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if (v != null)
            {
                v.Parent = u.Parent;
            }
        }

        private TreeNode Minimum(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        private void InorderTreeWalk(TreeNode node, Action<TreeNode> action)
        {
            if (node != null)
            {
                this.InorderTreeWalk(node.Left, action);
                action(node);
                this.InorderTreeWalk(node.Right, action);
            }
        }

        private void PreorderTreeWalk(TreeNode node, Action<TreeNode> action)
        {
            if (node != null)
            {
                action(node);
                this.PreorderTreeWalk(node.Left, action);
                this.PreorderTreeWalk(node.Right, action);
            }
        }

        private TreeNode Search(TreeNode node, TKey key)
        {
            int compare = key.CompareTo(node.Key);

            if (node == null || compare == 0)
            {
                return node;
            }

            if (compare < 0)
            {
                return this.Search(node.Left, key);
            }
            else
            {
                return this.Search(node.Right, key);
            }
        }

        /// <summary>
        /// TreeNode class for tree elements
        /// </summary>
        private class TreeNode
        {
            public TreeNode(TKey key, TValue value, TreeNode left, TreeNode right, TreeNode parent)
            {
                this.Key = key;
                this.Value = value;
                this.Left = left;
                this.Right = right;
                this.Parent = parent;
            }

            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public TreeNode Left { get; set; }

            public TreeNode Right { get; set; }

            public TreeNode Parent { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                TreeNode node = obj as TreeNode;

                if ((object)node == null)
                {
                    return false;
                }

                return this.Key.CompareTo(node.Key) == 0;
            }

            public override int GetHashCode()
            {
                return this.Key.GetHashCode() ^ this.Value.GetHashCode();
            }
        }
    }
}