namespace T04.MaxSequence
{
    using System;
    using Helper;

    /// <summary>
    /// 4. Write a program that finds the maximal sequence of equal elements in an array. Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
    /// </summary>
    public class MaxSequence
    {
        private static void Main()
        {
            int arrayLength = Helper.ValidateInputAsInt("Enter array length (integer value): ");

            int[] myArray = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = Helper.ValidateInputAsInt("Array value: ");
            }

            //// Quick tester
            //// int[] myArray = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

            int start = 0;
            int length = 1;

            int bestStart = 0;
            int bestLength = 1;

            // Find maximal sequence
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray[i] == myArray[i - 1])
                {
                    start = i;
                    length++;
                    if (length > bestLength)
                    {
                        bestStart = start;
                        bestLength = length;
                    }
                }
                else
                {
                    length = 1;
                }
            }

            // Print result
            Console.WriteLine("Length is: {0}", bestLength);
            Console.Write("Sequence: ");
            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(myArray[bestStart] + " ");
            }

            Console.WriteLine();
        }
    }
}
