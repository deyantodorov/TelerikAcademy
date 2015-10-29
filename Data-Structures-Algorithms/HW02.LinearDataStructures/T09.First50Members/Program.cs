namespace T09.First50Members
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 9. We are given the following sequence:
    ///    S1 = N;
    /// 
    ///    S2 = S1 + 1;
    ///    S3 = 2 * S1 + 1;
    ///    S4 = S1 + 2;
    /// 
    ///    S5 = S2 + 1;
    ///    S6 = 2 * S2 + 1;
    ///    S7 = S2 + 2;
    ///    
    ///    ...
    ///    Using the Queue<T> class write a program to print its first 50 members for given N.
    ///    Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            int n = 2;
            int limit = 17; // 50 / 3 ~ 17

            var multiplication = ResetMultiplication();
            var addition = ResetAddition();
            var result = new List<int> { n };

            for (int i = 0; i < limit; i++)
            {
                // Cal 3 values and add them to list of results
                var t1 = (multiplication.Dequeue() * result[i]) + addition.Dequeue();
                result.Add(t1);

                var t2 = (multiplication.Dequeue() * result[i]) + addition.Dequeue();
                result.Add(t2);

                var t3 = (multiplication.Dequeue() * result[i]) + addition.Dequeue();
                result.Add(t3);

                // Fill with default values
                multiplication = ResetMultiplication();
                addition = ResetAddition();
            }

            Console.WriteLine("Def: 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...");
            Console.Write("Res: " + string.Join(", ", result) + "\n");
        }

        /// <summary>
        /// Reset default values for multiplication
        /// </summary>
        private static Queue<int> ResetMultiplication()
        {
            var output = new Queue<int>();

            output.Enqueue(1);
            output.Enqueue(2);
            output.Enqueue(1);

            return output;
        }

        /// <summary>
        /// Reset default values for addition
        /// </summary>
        private static Queue<int> ResetAddition()
        {
            var output = new Queue<int>();

            output.Enqueue(1);
            output.Enqueue(1);
            output.Enqueue(2);

            return output;
        }
    }
}
