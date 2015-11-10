using System;

namespace T03.CombinationsNoDuplicates
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

            GenerateCombinationsNoDuplicates(0, 0);
        }

        private static void GenerateCombinationsNoDuplicates(int index, int start)
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
                    GenerateCombinationsNoDuplicates(index + 1, i + 1);
                }
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(", ", current));
        }
    }
}