namespace T16.SubsetOfElements
{
    using System;

    /// <summary>
    /// 16. * We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. 
    ///     Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
    /// </summary>
    public class SubsetOfElements
    {
        private static void Main()
        {
            int sum = 14;
            int[] myArray = { 2, 1, 2, 4, 3, 5, 2, 6 };

            SubsetSum(myArray, sum);
        }

        private static void SubsetSum(int[] array, long search)
        {
            long sum = search;
            long count = 0;

            long combindations = Pow(array.Length);

            for (int outside = 1; outside <= combindations; outside++)
            {
                int currentSum = 0;

                for (int j = 0; j <= array.Length; j++)
                {
                    if (((outside >> j) & 1) == 1)
                    {
                        currentSum += array[j];
                    }
                }

                if (currentSum == sum)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                Console.WriteLine("Subsets with sum {0} are {1}", sum, count);
            }
            else
            {
                Console.WriteLine("No subsets with sum {0}", sum);
            }
        }

        private static long Pow(int number)
        {
            long power = 1;

            for (int i = 1; i < number; i++)
            {
                power *= 2;
            }

            return power -= 1;
        }
    }
}
