namespace T08.SequenceOfMaxSum
{
    using System;

    /// <summary>
    /// 8. Write a program that finds the sequence of maximal sum in given array. Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
    ///    Can you do it with only one loop (with single scan through the elements of the array)?
    /// </summary>
    public class SequenceOfMaxSum
    {
        /// <summary>
        /// Kadane's algorithm
        /// </summary>
        /// <param name="array">find max sub array</param>
        /// <returns>int[0] - maxSum, int[1] - start elemenet, int[2] - end element</returns>
        public static int[] MaxSubsetSum(int[] array)
        {
            int maxSum = array[0];
            int tempSum = array[0];

            int begin = 0;
            int beginTemp = 0;
            int end = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (tempSum < 0)
                {
                    tempSum = array[i];
                    beginTemp = i;
                }
                else
                {
                    tempSum += array[i];
                }

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;

                    begin = beginTemp;
                    end = i;
                }
            }

            int[] result = new int[3];
            result[0] = maxSum;
            result[1] = begin;
            result[2] = end;

            return result;
        }

        private static void Main()
        {
            int[] myArray = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

            //// Store results here
            int[] result = MaxSubsetSum(myArray);

            Console.WriteLine("Max sum is: {0}", result[0]);

            Console.Write("Subset is: ");
            for (int i = result[1]; i <= result[2]; i++)
            {
                Console.Write("{0} ", myArray[i]);
            }

            Console.WriteLine();
        }
    }
}