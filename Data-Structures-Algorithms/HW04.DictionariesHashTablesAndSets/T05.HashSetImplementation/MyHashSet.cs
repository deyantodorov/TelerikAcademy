namespace T05.HashSetImplementation
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using T04.HashTableImplementation;

    public class MyHashSet<T> : IEnumerable<T>
    {
        private MyHashTable<int, T> hashTable;

        public MyHashSet()
        {
            this.hashTable = new MyHashTable<int, T>();
        }

        public int Count
        {
            get { return this.hashTable.Count; }
        }

        public void Add(T value)
        {
            this.hashTable.Add(value.GetHashCode(), value);
        }

        public bool Contains(T value)
        {
            return this.hashTable.Contains(value.GetHashCode());
        }

        public void Remove(T value)
        {
            this.hashTable.Remove(value.GetHashCode());
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void UnionWith(MyHashSet<T> other)
        {
            var current = this.hashTable;
            this.hashTable.Clear();

            var newHashTable = new MyHashTable<int, T>();

            foreach (var pair in current)
            {
                newHashTable.Add(pair.Key, pair.Value);
            }

            foreach (var pair in other)
            {
                newHashTable.Add(pair.GetHashCode(), pair);
            }

            this.hashTable = newHashTable;
        }

        public void IntersectWith(MyHashSet<T> other)
        {
            var newHashTable = new MyHashTable<int, T>();

            foreach (var item in other)
            {
                if (this.hashTable.Contains(item.GetHashCode()))
                {
                    newHashTable.Add(item.GetHashCode(), item);
                }
            }

            this.hashTable=newHashTable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.hashTable.Select(pair => pair.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in this.hashTable.Keys)
            {
                sb.AppendFormat(" {0},", item);
            }

            sb.Length--;
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
