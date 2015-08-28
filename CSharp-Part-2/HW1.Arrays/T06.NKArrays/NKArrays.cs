namespace T06.NKArrays
{
    using System;
    using Helper;

    /// <summary>
    /// 6. Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.
    /// </summary>
    public class NKArrays
    {
        private static void Main()
        {
            int n = Helper.ValidateInputAsInt("Value for N: ");

            int[] myArray = new int[n];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = Helper.ValidateInputAsInt("Enter array value: ");
            }

            int k = Helper.ValidateInputAsInt("Value for K: ");

            if (k <= n)
            {
                int bestStart = 0;
                int bestEnd = 0;
                int bestSum = 0;

                //// Quick test
                //// int[] myArray = { 30, 2, 3, 4, 5, 2, 1, 2, 3, 4};
                for (int i = 0; i < myArray.Length - k + 1; i++)
                {
                    int start = myArray[i];
                    int end = 0;
                    int sum = start;

                    for (int j = i + 1; j < i + k; j++)
                    {
                        end = myArray[j];
                        sum += end;
                    }

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestStart = i;
                        bestEnd = i + k;
                    }
                }

                Console.WriteLine("Start {0}", bestStart);
                Console.WriteLine("End {0}", bestEnd);
                Console.WriteLine("Sum {0}", bestSum);
                Console.Write("Elements: ");
                
                for (int i = bestStart; i < bestEnd; i++)
                {
                    Console.Write("{0} ", myArray[i]);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("K can't be greater than array length N");
            }
        }
    }
}