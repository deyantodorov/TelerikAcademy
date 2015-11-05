namespace T04.HashTableImplementation
{
    using System;

    /// <summary>
    /// 4. Implement the data structure hash table in a class HashTable<K,T>. Keep the data in array of lists of 
    /// key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load runs over 75%, 
    /// perform resizing to 2 times larger capacity. 
    ///     Implement the following methods and properties:
    ///     Add(key, value)
    ///     Find(key)->value
    ///     Remove(key)
    ///     Count
    ///     Clear()
    ///     this[]
    ///     Keys
    ///     Try to make the hash table to support iterating over its elements with foreach.
    ///     Write unit tests for your class.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var hashTable = new MyHashTable<string, int>();

            hashTable.Add("five", 5);
            hashTable.Add("six", 6);

            Console.WriteLine(hashTable.Find("five"));
            // throws exception
            //Console.WriteLine(hashTable.Find("seven"));

            //test auto grow

            for (int i = 0; i < 16; i++)
            {
                hashTable.Add(i.ToString(), i);
                Console.WriteLine(hashTable.Count);
            }

            Console.WriteLine(hashTable.Find("five"));
            Console.WriteLine(hashTable.Find("9"));

            Console.WriteLine(hashTable.Count);
            hashTable.Remove("9");
            Console.WriteLine(hashTable.Count);

            Console.WriteLine("test indexator");
            Console.WriteLine(hashTable["10"]);
            hashTable["10"]++;
            Console.WriteLine(hashTable["10"]);
            // throws exception
            //Console.WriteLine(hashTable.Find("9"));

            Console.WriteLine("Test HashTable.Keys enumerator:");
            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Test HashTable enumerator:");
            foreach (var pair in hashTable)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
