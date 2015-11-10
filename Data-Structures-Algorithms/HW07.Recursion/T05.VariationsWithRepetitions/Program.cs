using System;

namespace T05.VariationsWithRepetitions
{
    /// <summary>
    /// 5. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
    ///  Example: n=3, k=2, set = {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    public class Program
    {
        private static int n = 3;
        private static int k = 2;
        private static readonly string[] items = new string[] { "hi", "a", "b" };
        private static readonly string[] output = new string[k];

        private static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    output[index] = items[i];
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine("{ " + string.Join(", ", output) + " }");
        }
    }
}
