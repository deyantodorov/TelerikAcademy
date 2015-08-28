namespace T14.QuickSort
{
    using System;

    /// <summary>
    /// 14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
    /// </summary>
    public class QuickSort
    {
        private static void Main()
        {
            string[] letters = { "s", "o", "m", "t", "h", "i", "n", "g" };

            Console.Write("Letters unsorted: ");
            PrintMe(letters);

            // Quick Sort of strings
            QuickSorter(letters, 0, letters.Length - 1);
            Console.Write("Letters usorted: ");
            PrintMe(letters);

            Console.WriteLine();
            int[] digits = { 4, 3, 1, 4, 2, 5, 8 };            

            Console.Write("Digits unsorted: ");
            PrintMe(digits);

            // Quick Sort of int as strings            
            QuickSorter(digits, 0, digits.Length - 1);
            Console.Write("Digits sorted: ");
            PrintMe(digits);
        }

        /// <summary>
        /// Quick sort algorithm
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="arrayToSort">array to sort</param>
        /// <param name="left">first element of array</param>
        /// <param name="right">last element of array</param>
        private static void QuickSorter<T>(T[] arrayToSort, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;

            // Instead of left / 2 we use left shift with 1 position
            IComparable pivot = arrayToSort[(left >> 1) + (right >> 1)];

            while (i <= j)
            {
                while (arrayToSort[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arrayToSort[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap values
                    var temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[j];
                    arrayToSort[j] = temp;

                    i++;
                    j--;
                }

                // Recursive calls
                if (left < j)
                {
                    QuickSorter(arrayToSort, left, j);
                }

                if (i < right)
                {
                    QuickSorter(arrayToSort, i, right);
                }
            }
        }

        /// <summary>
        /// Help method for printing
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="array">array to print</param>
        private static void PrintMe<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }
    }
}
