namespace T11.BinarySearch
{
    using System;
    using Helper;

    /// <summary>
    /// 11. Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
    /// </summary>
    public class BinarySearch
    {
        private static void Main()
        {
            Console.Write("Array: ");
            int[] myArray = { 7, 3, 1, 4, 2, 5, 8 };

            Helper.PrintArray<int>(myArray);

            int search = Helper.ValidateInputAsInt("Search in array for: ");
            int position = Array.IndexOf(myArray, search);

            Array.Sort(myArray);

            int findRecursive = BinarySearchRecursive(myArray, search, 0, myArray.Length - 1);
            int findIterative = BinSearchIterative(myArray, search);

            // Just testing different implementation of Binary Search: Iterative and Recursive version
            if (findRecursive == -1 && findIterative == -1)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Console.WriteLine("Found value {0} at position {1}", search, position);
            }
        }

        private static int BinSearchIterative(int[] array, int search)
        {
            int start = 0;
            int end = array.Length - 1;
            int position = -1;

            while (start <= end && position == -1)
            {
                int mid = start + (end - start) / 2;

                if (search < array[mid])
                {
                    end = mid - 1;
                }
                else if (search > array[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    position = mid;
                }
            }

            return position;
        }

        private static int BinarySearchRecursive(int[] array, int search, int start, int end)
        {
            int position = -1;

            if (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (search < array[mid])
                {
                    position = BinarySearchRecursive(array, search, start, mid - 1);
                }
                else if (search > array[mid])
                {
                    position = BinarySearchRecursive(array, search, mid + 1, end);
                }
                else
                {
                    position = mid;
                }
            }

            return position;
        }
    }
}
