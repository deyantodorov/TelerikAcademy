namespace T17.SubsetOfElementsDynamic
{
    using System;
    using Helper;

    public class SubsetOfElementsDynamic
    {
        private static void Main()
        {
            int n = Helper.ValidateInputAsInt("Array length: ");
            int k = Helper.ValidateInputAsInt("Numbers to sum: ");
            int s = Helper.ValidateInputAsInt("Desired sum: ");

            int[] myArray = new int[n];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = Helper.ValidateInputAsInt("Value: ");
            }

            SubsetSum(myArray, s, k);
        }

        private static void SubsetSum(int[] array, long search, long length)
        {
            long count = 0;

            long combindations = Pow(array.Length);

            for (int outside = 1; outside <= combindations; outside++)
            {
                int currentSum = 0;
                int currentLength = 0;

                for (int j = 0; j <= array.Length; j++)
                {
                    if (((outside >> j) & 1) == 1)
                    {
                        currentSum += array[j];
                        currentLength++;
                    }
                }

                if (currentSum == search && currentLength == length)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                Console.WriteLine("Subsets with sum {0} and length {1} are {2}", search, length, count);
            }
            else
            {
                Console.WriteLine("No subsets with sum {0} and length {1}", search, length);
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
