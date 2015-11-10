using System;

namespace T04.GeneratePermutations
{
    public class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine() ?? "");
            var array = GenerateSortedArray(n);
            PermutateWithRepetitions(array, 0, array.Length);
        }

        private static void PermutateWithRepetitions(int[] array, int start, int length)
        {
            Print(array);

            for (int left = length - 2; left >= start; left--)
            {
                for (int right = left + 1; right < length; right++)
                {
                    if (array[left] == array[right])
                    {
                        continue;
                    }

                    Swap(ref array[left], ref array[right]);
                    PermutateWithRepetitions(array, left + 1, length);
                }

                // Undo all modifications done by the previous 
                // recursive calls and swaps
                var firstElement = array[left];

                for (int i = left; i < length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[length - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private static int[] GenerateSortedArray(int length)
        {
            var array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }
    }
}
