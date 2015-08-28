namespace Helper
{
    using System;

    /// <summary>
    /// Helper array methods
    /// </summary>
    public class Arrays
    {
        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        public static void PrintMultiArray<T>(T[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write("{0} ", array[row, col].ToString().PadLeft(2));
                }

                Console.WriteLine();
            }
        }
    }
}
