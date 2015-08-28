namespace T09.MostFrequentNumber
{
    using System;
    using Helper;

    /// <summary>
    /// 9. Write a program that finds the most frequent number in an array. Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
    /// </summary>
    public class MostFrequentNumber
    {
        private static void Main()
        {
            int[] myArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            int bestCount = 0;
            int bestValue = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                int currentCount = 0;

                for (int j = 0; j < myArray.Length; j++)
                {
                    if (myArray[i] == myArray[j])
                    {
                        currentCount++;
                    }
                }

                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestValue = myArray[i];
                }
            }

            Console.Write("Array: ");
            Helper.PrintArray<int>(myArray);
            Console.WriteLine("Result: {0} ({1} times)", bestValue, bestCount);
        }
    }
}
