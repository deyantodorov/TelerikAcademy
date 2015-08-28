namespace T05.MaxIncreasingSequence
{
    using System;

    /// <summary>
    /// 5. Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
    /// </summary>
    class MaxIncreasingSequence
    {
        static void Main()
        {
            int[] myArray = { 3, 2, 3, 4, 5, 2, 2, 3, 4, 5, 6, 7, 8 };

            int start = 0;
            int length = 1;

            int bestStart = 0;
            int bestLength = 1;

            // Find maximal sequence
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray[i] == myArray[i - 1] + 1)
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
                Console.Write(myArray[bestStart - bestLength + 1] + " ");
                bestStart++;
            }

            Console.WriteLine();
        }
    }
}
