using System;

namespace IteratorPattern
{
    public class Program
    {
        private static void Main()
        {
            var collection = new Collection();

            for (int i = 0; i < 10; i++)
            {
                collection[i] = new Item($"Item {i}");
            }

            // create iterator
            var iterator = new Iterator(collection)
            {
                Step = 2
            };

            Console.WriteLine("Iterating over collection: ");

            for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);               
            }
        }
    }
}
