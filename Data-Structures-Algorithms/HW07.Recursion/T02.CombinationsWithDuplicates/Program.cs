using System;

namespace T02.CombinationsWithDuplicates
{
    public class Program
    {
        private static int n;
        private static int k;
        private static int[] current;

        private static void Main()
        {
            n = 4;
            k = 2;
            current = new int[k];

            GenerateCombinationsWithDuplicates(0, 0);
        }

        private static void GenerateCombinationsWithDuplicates(int index, int start)
        {
            if (index >= k)
            {
                PrintNumbers();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    current[index] = i + 1;
                    GenerateCombinationsWithDuplicates(index + 1, i);
                }
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(", ", current));
        }
    }
}
