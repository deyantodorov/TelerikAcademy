namespace T13.QueueImplementation
{
    using System;

    public class Program
    {
        private static void Main()
        {
            var queue = new QueueCustom<string>();

            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");
            queue.Enqueue("Message Five");

            while (queue.Count > 0)
            {
                string message = queue.Dequeue();
                Console.WriteLine(message);
            }
        }
    }
}
