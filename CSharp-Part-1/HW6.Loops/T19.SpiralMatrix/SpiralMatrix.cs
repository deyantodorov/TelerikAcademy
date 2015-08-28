namespace T19.SpiralMatrix
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 19. Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix 
    ///     holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
    /// </summary>
    public class SpiralMatrix
    {
        private static void Main()
        {
            int n = Helpers.ValidateInputAsInt("Enter value for n = ");

            while (n == 0 || n > 20)
            {
                n = Helpers.ValidateInputAsInt("Enter value for n = ");
            }

            int[,] matrix = new int[n, n];
            int maxNumber = n * n;
            int row = 0;
            int col = 0;
            string direction = "right";

            for (int i = 1; i <= maxNumber; i++)
            {
                if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }

                if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    col--;
                    row--;
                }

                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }

                if (direction == "up" && (row < 0 || matrix[row, col] != 0))
                {
                    direction = "right";
                    col++;
                    row++;
                }

                matrix[row, col] = i;

                if (direction == "right")
                {
                    col++;
                }

                if (direction == "down")
                {
                    row++;
                }

                if (direction == "left")
                {
                    col--;
                }

                if (direction == "up")
                {
                    row--;
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c].ToString().PadLeft(3));
                }

                Console.WriteLine();
            }
        }
    }
}