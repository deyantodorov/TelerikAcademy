namespace T21.Combinations
{
    using System;
    using Helper;

    /// <summary>
    /// 21. Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
    ///     Example: N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
    /// </summary>
    public class Combinations
    {
        private static void Main()
        {
            int numOfDigits = Helper.ValidateInputAsInt("Number of digits: ");
            int numOfCombinations = Helper.ValidateInputAsInt("Combinations: ");
            int[] myArray = new int[numOfCombinations];

            CombinationsNoRepetitions(0, 0, numOfCombinations, numOfDigits, myArray);
        }

        private static void CombinationsNoRepetitions(int index, int start, int combinations, int digits, int[] array)
        {
            if (index >= combinations)
            {
                PrintVariations(array);
            }
            else
            {
                for (int i = start; i < digits; i++)
                {
                    array[index] = i;
                    CombinationsNoRepetitions(index + 1, i + 1, combinations, digits, array);
                }
            }
        }

        private static void PrintVariations(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + 1 + " ");
            }

            Console.WriteLine();
        }
    }
}
