namespace T19.Permutations
{
    using System;
    
    /// <summary>
    /// 19. * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
    ///       Example: n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    /// </summary>
    public class Permutations
    {
        private static readonly int N = int.Parse(Console.ReadLine());
        private static readonly int[] Array = new int[N];

        private static void Main()
        {
            for (int i = 0; i < N; i++)
            {
                Array[i] = i;
            }

            Permute(N);
        }

        private static void Permute(int n)
        {
            int i, swap;
            
            if (n == 0)
            {
                Print();
            }
            else
            {
                Permute(n - 1);

                for (i = 0; i < n - 1; i++)
                {
                    swap = Array[i];
                    Array[i] = Array[n - 1];
                    Array[n - 1] = swap;

                    Permute(n - 1);

                    swap = Array[i];
                    Array[i] = Array[n - 1];
                    Array[n - 1] = swap;
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", Array[i] + 1);
            }

            Console.WriteLine();
        }
    }
}
