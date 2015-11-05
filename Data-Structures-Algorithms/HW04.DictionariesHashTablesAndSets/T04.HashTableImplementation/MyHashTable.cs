namespace T04.HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyHashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const double MaxCapacityCoefficent = 0.75d;
        private const int Capacity = 16;
        private LinkedList<KeyValuePair<TKey, TValue>>[] table;
        private int count;
        private int listCount;

        public MyHashTable()
        {
            this.table = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];
            this.count = 0;
            this.listCount = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return from list in this.table
                       where list != null
                       from pair in list
                       select pair.Key;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return from list in this.table
                       where list != null
                       from pair in list
                       select pair.Value;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.Remove(key);
                this.Add(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (this.listCount >= this.table.Length * MaxCapacityCoefficent)
            {
                this.ResizeTable();
            }

            var pairToAdd = new KeyValuePair<TKey, TValue>(key, value);
            int hash = this.GetHashCode(key);

            // Lazy initialization of LinkedList
            if (this.table[hash] == null)
            {
                this.table[hash] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.listCount++;
            }

            // Chech for matching keys
            if (this.table[hash].Any(pair => pair.Key.Equals(key)))
            {
                throw new ArgumentException("HashTable already contains key - " + key);
            }

            this.table[hash].AddLast(pairToAdd);
            this.count++;
        }

        public TValue Find(TKey key)
        {
            return this.FindPair(key).Value;
        }

        public void Remove(TKey key)
        {
            if (this.TryRemove(key))
            {
                return;
            }

            throw new ArgumentException("HashTable doesn't contain key - " + key);
        }
        
        public void Clear()
        {
            this.table = new LinkedList<KeyValuePair<TKey, TValue>>[this.table.Length];
            this.count = 0;
        }

        public bool Contains(TKey key)
        {
            int hash = this.GetHashCode(key);
            return this.table[hash] != null && this.table[hash].Any(pair => pair.Key.Equals(key));
        }
        
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.table
                .Where(list => list != null)
                .SelectMany(list => list)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool TryRemove(TKey key)
        {
            int hash = this.GetHashCode(key);
            var pairToRemove = new KeyValuePair<TKey, TValue>();

            if (this.table[hash] == null)
            {
                return false;
            }

            bool isPairFound = false;

            foreach (var pair in this.table[hash].Where(pair => pair.Key.Equals(key)))
            {
                pairToRemove = pair;
                isPairFound = true;
                break;
            }

            if (!isPairFound)
            {
                return false;
            }

            this.table[hash].Remove(pairToRemove);
            this.count--;
            return true;
        }

        private KeyValuePair<TKey, TValue> FindPair(TKey key)
        {
            int hash = this.GetHashCode(key);

            if (this.table[hash] != null)
            {
                foreach (var pair in this.table[hash])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair;
                    }
                }
            }

            throw new ArgumentException("HashTable doesn't contain key - " + key);
        }

        private void ResizeTable()
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] old = this.table;
            this.table = new LinkedList<KeyValuePair<TKey, TValue>>[old.Length * 2];
            this.listCount = 0;

            foreach (var list in old)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        this.AddPairResize(pair);
                    }
                }
            }
        }

        private void AddPairResize(KeyValuePair<TKey, TValue> pair)
        {
            int hash = this.GetHashCode(pair.Key);

            if (this.table[hash] == null)
            {
                this.table[hash] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.listCount++;
            }

            this.table[hash].AddLast(pair);
        }

        private int GetHashCode(TKey key)
        {
            var hash = key.GetHashCode();
            hash %= this.table.Length;
            hash = Math.Abs(hash);

            return hash;
        }
    }
}