namespace T01.PriorityQueueImplementation
{
    using System;

    /// <summary>
    /// 1. Implement a class PriorityQueue<T> based on the data structure "binary heap".
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var pq = new PriorityQueue<int, string>();

            pq.Enqueue(1, "Pesho");
            pq.Enqueue(23, "Pesho1");
            pq.Enqueue(12, "Pesho2");
            pq.Enqueue(13, "Pesho3");
            pq.Enqueue(14, "Pesho4");
            pq.Enqueue(15, "Pesho5");

            Console.WriteLine(pq.Count);
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Count);
        }
    }
}
