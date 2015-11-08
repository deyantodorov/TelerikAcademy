namespace T10.ShortestSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 10. We are given numbers N and M and the following operations:
    ///     N = N+1
    ///     N = N+2
    ///     N = N*2
    ///     
    ///     Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
    ///     
    ///     Hint: use a queue.
    ///     Example: N = 5, M = 16
    ///     Sequence: 5 → 7 → 8 → 16
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            int n = 5;
            int m = 16;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            Console.WriteLine("N = {0}", n);
            Console.WriteLine("M = {0}", m);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.Write("{0} ", current);

                if (current == m)
                {
                    Console.WriteLine();
                    return;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue(current + 2);
                queue.Enqueue(current * 2);
            }
        }
    }
}
