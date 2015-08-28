namespace T20.Variations
{
    using System;
    using Helper;

    /// <summary>
    /// 20. Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
    ///     Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
    /// </summary>
    public class Variations
    {
        private static void Main()
        {
            int max = Helper.ValidateInputAsInt("Variations limit: ");
            int digits = Helper.ValidateInputAsInt("Digits: ");

            int[] myArray = new int[digits];

            VariateWithRepetition(0, max, digits, ref myArray);
        }

        private static void VariateWithRepetition(int index, int max, int digits, ref int[] array)
        {
            if (index >= digits)
            {
                PrintVariations(ref array);
            }
            else
            {
                for (int i = 0; i < max; i++)
                {
                    array[index] = i;
                    VariateWithRepetition(index + 1, max, digits, ref array);
                }
            }
        }

        private static void PrintVariations(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + 1 + " ");
            }

            Console.WriteLine();
        }
    }
}