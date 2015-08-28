namespace T13.MergeSort
{
    using System;

    /// <summary>
    /// 13. * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
    /// </summary>
    public class MergeSort
    {
        private static void Main()
        {
            int[] myIntArray = new int[] { 4, 3, 1, 4, 2, 5, 8 };
            string[] myStringArray = new string[] { "s", "o", "m", "e", "t", "h", "i", "n", "g" };

            Console.WriteLine("Unsorted: ");
            PrintMe<int>(myIntArray);
            PrintMe<string>(myStringArray);

            MergeSorting<int>(myIntArray, 0, myIntArray.Length - 1);
            MergeSorting<string>(myStringArray, 0, myStringArray.Length - 1);

            Console.WriteLine("Sorted: ");
            PrintMe(myIntArray);
            PrintMe<string>(myStringArray);
        }

        /// <summary>
        /// Help printing method
        /// </summary>
        /// <param name="array">array to be printed</param>
        private static void PrintMe<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Merge sorting algorithm
        /// </summary>
        /// <typeparam name="T">Abstract Type - T</typeparam>
        /// <param name="array">array to be sorted</param>
        /// <param name="left">first element</param>
        /// <param name="right">last element</param>
        private static void MergeSorting<T>(T[] array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSorting<T>(array, left, middle);
                MergeSorting<T>(array, middle + 1, right);

                T[] leftArray = new T[middle - left + 1];
                T[] rightArray = new T[right - middle];

                Array.Copy(array, left, leftArray, 0, middle - left + 1);
                Array.Copy(array, middle + 1, rightArray, 0, right - middle);

                for (int i = 0, j = 0, k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i].CompareTo(rightArray[j]) <= 0)
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
