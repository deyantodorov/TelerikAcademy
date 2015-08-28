namespace T18.LIS
{
    using System;
    using Helper;

    /// <summary>
    /// 18. * Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order. 
    ///       Print the remaining sorted array. Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
    /// </summary>
    public class LIS
    {
        private static void Main()
        {
            // Quick test
            //int[] myArray = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

            // Initialize array
            int arrayLength = Helper.ValidateInputAsInt("Enter array length: ");
            int[] myArray = new int[arrayLength];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = Helper.ValidateInputAsInt("Value: ");
            }

            ShowLis(myArray);
        }

        private static void ShowLis(int[] array)
        {
            // Store paths and sizes
            string[] pathsForPrinting = new string[array.Length];
            int[] subSequenceSizes = new int[array.Length];

            // Initialize paths and sizes
            for (int i = 0; i < array.Length; i++)
            {
                subSequenceSizes[i] = 1;
                pathsForPrinting[i] = array[i] + " ";
            }

            int maxLength = 1;

            // Longest increasing subsequence algorithm
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] >= array[j] && subSequenceSizes[i] < subSequenceSizes[j] + 1)
                    {
                        subSequenceSizes[i] = subSequenceSizes[j] + 1;
                        pathsForPrinting[i] = pathsForPrinting[j] + array[i] + " ";

                        if (maxLength < subSequenceSizes[i])
                        {
                            maxLength = subSequenceSizes[i];
                        }
                    }
                }
            }

            // Print result
            for (int i = 0; i < array.Length; i++)
            {
                if (subSequenceSizes[i] == maxLength)
                {
                    Console.WriteLine("Result: {0}", pathsForPrinting[i]);
                }
            }
        }
    }
}