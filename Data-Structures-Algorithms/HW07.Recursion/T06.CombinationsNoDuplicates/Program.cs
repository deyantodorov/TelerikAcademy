using System;

namespace T06.CombinationsNoDuplicates
{
    public class Program
    {
        private static int n = 3;
        private static int k = 2;
        private static readonly string[] input = { "test", "rock", "fun" };
        private static readonly string[] output = new string[2];

        private static void Main()
        {
            GenerateCombinationsNoDuplicates(0, 0);
        }

        private static void GenerateCombinationsNoDuplicates(int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine("{ " + string.Join(", ", output) + " }");
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    output[index] = input[i];
                    GenerateCombinationsNoDuplicates(index + 1, i + 1);
                }
            }
        }
    }
}
