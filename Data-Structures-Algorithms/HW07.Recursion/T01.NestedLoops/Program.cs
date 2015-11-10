using System;

namespace T01.VariationsWithRepetitions
{
    /// <summary>
    /// 1. Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
    /// </summary>
    public class Program
    {
        private static int n;
        private static int k;
        private static int[] numbers;
        private static int[] current;

        private static void Main()
        {
            Console.Write("Enter some integer: ");
            n = int.Parse(Console.ReadLine() ?? "0");
            k = n;
            numbers = new int[n];
            current = new int[k];

            for (int i = 0; i < k; i++)
            {
                numbers[i] = i + 1;
            }

            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    current[index] = i + 1;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine(string.Join(", ", current));
        }
    }
}
