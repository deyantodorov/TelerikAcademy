namespace T12.RandomizeNumbers
{
    using System;
    using Common;

    /// <summary>
    /// 12. Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
    /// </summary>
    public class RandomizeNumbers
    {
        /// <summary>
        /// Used in Shuffle(T)
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Shuffle the array with Fisher-Yates shuffle algorithm
        /// </summary>
        /// <typeparam name="T">Array element type</typeparam>
        /// <param name="array">Array to shuffle</param>
        private static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                T temp = array[r];
                array[r] = array[i];
                array[i] = temp;
            }
        }

        private static void Print<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        private static void Main()
        {
            var n = Helpers.ValidateInputAsInt("Enter some integer: ");
            var array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            Console.WriteLine();
            Console.WriteLine("Print before randomization: ");
            Print(array);

            Shuffle(array);

            Console.WriteLine();
            Console.WriteLine("Print after randomization: ");
            Print(array);
        }
    }
}