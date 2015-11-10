using System;

namespace T11.PermutationsWithRepetitions
{
    /// <summary>
    /// 11. *Write a program to generate all permutations with repetitionsof given multi-set.
    ///      Example: the multi-set {1, 3, 5, 5}
    ///      has the following 12 unique permutations:
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var arr = new int[] { 1, 3, 5, 5 };
            Array.Sort(arr);
            GeneratePermutationsWithRepetitions(arr, 0, arr.Length);
        }

        private static void GeneratePermutationsWithRepetitions(int[] arr, int start, int n)
        {
            Print(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] == arr[right])
                    {
                        continue;
                    }

                    Swap(ref arr[left], ref arr[right]);
                    GeneratePermutationsWithRepetitions(arr, left + 1, n);
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];

                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}