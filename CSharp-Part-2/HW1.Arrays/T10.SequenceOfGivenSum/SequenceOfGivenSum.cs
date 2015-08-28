namespace T10.SequenceOfGivenSum
{
    using System;
    using Helper;

    /// <summary>
    /// 10. Write a program that finds in given array of integers a sequence of given sum S (if present). Example: {4, 3, 1, 4, 2, 5, 8}, S = 11 -> {4, 2, 5}
    /// </summary>
    class SequenceOfGivenSum
    {
        static void Main()
        {
            int[] myArray = { 4, 3, 1, 4, 2, 5, 8 };

            Helper.PrintArray<int>(myArray);

            int targetSum = Helper.ValidateInputAsInt("Enter target sum: ");

            bool noSum = false;

            for (int i = 0; i < myArray.Length; i++)
            {
                int tempSum = 0;

                for (int j = i; j < myArray.Length; j++)
                {
                    tempSum += myArray[j];

                    if (tempSum == targetSum)
                    {
                        noSum = true;

                        //// Print sub array with target sum
                        for (int k = i; k <= j; k++)
                        {
                            Console.Write("{0} ", myArray[k]);
                        }
                        Console.WriteLine();
                    }

                    if (tempSum > targetSum)
                    {
                        break;
                    }
                }
            }

            if (!noSum)
            {
                Console.WriteLine("No such sum: {0}!", targetSum);
            }
        }
    }
}