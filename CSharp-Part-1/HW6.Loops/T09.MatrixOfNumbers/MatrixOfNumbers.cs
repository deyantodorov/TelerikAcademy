namespace T09.MatrixOfNumbers
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 9. Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix like in the examples below. Use two nested loops.
    /// </summary>
    public class MatrixOfNumbers
    {
        private static void Main()
        {
            uint n = Helpers.ValidateInputAsUint("Enter value for n = ");

            while (n > 20)
            {
                n = Helpers.ValidateInputAsUint("Enter value for n = ");
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 1)
                    {
                        Console.Write(j.ToString().PadLeft(3));
                    }
                    else
                    {
                        Console.Write((j + i - 1).ToString().PadLeft(3));
                    }
                }

                Console.WriteLine();
            }
        }
    }
}