namespace T04.CountValue
{
    using System;

    /// <summary>
    /// 4. Write a method that counts how many times given number appears in given array. 
    ///    Write a test program to check if the method is working correctly.
    /// </summary>
    public class CountValue
    {
        private static void Main()
        {
            int[] array = { 1, 2, 2, 2, 3, 4, 1, 5, 6, 7, 8, 2, 4, 3, 2 };
            Console.WriteLine(Count<int>(array, 2));

            string[] array2 = { "la", "la", "pa", "la", "ga", "la" };
            Console.WriteLine(Count<string>(array2, "la"));
        }

        public static int Count<T>(T[] array, T value) where T : IComparable
        {
            int repeats = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (value.CompareTo(array[i]) == 0)
                {
                    repeats++;
                }
            }

            return repeats;
        }
    }
}
