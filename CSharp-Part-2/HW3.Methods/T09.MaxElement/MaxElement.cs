namespace T09.MaxElement
{
    using System;
    using System.Linq;
    using Helper;
    using System.Collections.Generic;

    /// <summary>
    /// 9. Write a method that return the maximal element in a portion of array of integers starting at given index. 
    ///    Using it write another method that sorts an array in ascending / descending order.
    /// </summary>
    public class MaxElement
    {
        private static void Main()
        {
            int[] array = { 100, 3, 1, 4, 13, 91, 31, 1, 2, 3, 5, 71231, 999 };
            Console.Write("Array: ");
            Helper.PrintArray<int>(array);

            int start = Helper.ValidateInputAsInt("Start index: ");

            FindMax(array, start);
        }

        private static void FindMax(int[] array, int start)
        {
            if (start < 0 || start > array.Length - 1)
            {
                throw new ArgumentException("Looking number is outside of array");
            }

            int maxNum = int.MinValue;

            for (int i = start; i < array.Length; i++)
            {
                if (array[i] > maxNum)
                {
                    maxNum = array[i];
                }
            }

            Console.WriteLine("Max number is: " + maxNum);

            int[] slicedArray = CopyArrayPartial(array, start);
            
            SortAsc(slicedArray);
            SortDesc(slicedArray);
        }

        private static void SortAsc(int[] array)
        {
            array = array.OrderBy(x => x).ToArray();
            Console.Write("Asc: ");
            Helper.PrintArray<int>(array);
        }

        private static void SortDesc(int[] array)
        {
            array = array.OrderByDescending(x => x).ToArray();
            Console.Write("Desc: ");
            Helper.PrintArray<int>(array);
        }

        private static T[] CopyArrayPartial<T>(T[] array, int start)
        {
            List<T> list = new List<T>();

            for (int i = start; i < array.Length; i++)
            {
                list.Add(array[i]);
            }

            return list.ToArray();
        }
    }
}
