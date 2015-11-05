namespace T05.HashSetImplementation
{
    using System;

    /// <summary>
    /// 5. Implement the data structure set in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. 
    ///    Implement all standard set operations like
    ///    Add(T)
    ///    Find(T)
    ///    Remove(T)
    ///    Count
    ///    Clear()
    ///    union and
    ///    intersect
    /// Write unit tests for your class.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var hashSet = new MyHashSet<int>();
            var otherSet = new MyHashSet<int>();

            for (int i = 0; i < 20; i++)
            {
                hashSet.Add(i);
                otherSet.Add(i + 1);
            }

            Console.WriteLine("Test intersect:");
            otherSet.IntersectWith(hashSet);
            Console.WriteLine(otherSet);

            otherSet.Add(-1);
            otherSet.Add(1000);
            Console.WriteLine("Test union:");
            otherSet.UnionWith(hashSet);
            Console.WriteLine(otherSet);
        }
    }
}
