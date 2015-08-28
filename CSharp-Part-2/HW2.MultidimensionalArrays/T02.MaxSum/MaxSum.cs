namespace T02.MaxSum
{
    using System;
    using Helper;

    /// <summary>
    /// 2. Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
    /// </summary>
    public class MaxSum
    {
        private static void Main()
        {
            //// Read width and heigth
            int width = Helper.ValidateInputAsInt("Matrix width (N): ");
            int heigth = Helper.ValidateInputAsInt("Matrix heigth (M): ");

            if (width < 3 || heigth < 3)
            {
                Console.WriteLine("Can't find matrix less than 3x3");
            }
            else
            {
                //// Initialize matrix with random values for easy checking
                int[,] matrix = new int[width, heigth];

                Random rand = new Random();

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        matrix[r, c] = rand.Next(100);
                    }
                }

                Console.WriteLine("Matrix: ");
                Helper.PrintMultiArray<int>(matrix);

                FindMaxSum(matrix);    
            }
        }

        private static void FindMaxSum(int[,] matrix)
        {
            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int r = 0; r <= matrix.GetLength(0) - 3; r++)
            {
                int currentSum = 0;

                for (int c = 0; c <= matrix.GetLength(1) - 3; c++)
                {
                    currentSum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2] +
                                 matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2] +
                                 matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestRow = r;
                        bestCol = c;
                    }
                }
            }

            Print(matrix, bestRow, bestCol, maxSum);
        }

        private static void Print(int[,] matrix, int bestRow, int bestCol, int maxSum)
        {
            Console.WriteLine();
            Console.WriteLine("Max sum square: ");
            Console.WriteLine("{0} {1} {2}", matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1], matrix[bestRow, bestCol + 2]);
            Console.WriteLine("{0} {1} {2}", matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1], matrix[bestRow + 1, bestCol + 2]);
            Console.WriteLine("{0} {1} {2}", matrix[bestRow + 2, bestCol], matrix[bestRow + 2, bestCol + 1], matrix[bestRow + 2, bestCol + 2]);
            Console.WriteLine("Max sum = {0}", maxSum);
            Console.WriteLine();
        }
    }
}
