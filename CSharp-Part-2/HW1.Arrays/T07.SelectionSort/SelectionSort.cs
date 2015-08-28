namespace T07.SelectionSort
{
    using System;

    /// <summary>
    /// 7. Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: 
    ///    Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
    /// </summary>
    public class SelectionSort
    {
        private static void Main()
        {
            int[] myArray = { 30, 2, 3, 4, 5, 2, 1, 2, 3, 4 };

            Console.Write("Unsorted: ");
            Print<int>(myArray);

            //// Selection sort algorithm
            int[] myArraySorted = SelSort(myArray);

            Console.Write("Sorted: ");
            Print<int>(myArraySorted);
        }

        private static void Print<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        private static int[] SelSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];

                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}
