namespace V4.P3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToList();


            BigInteger[,] matrix = FillMatrix(row, col);
            // Print<long>(matrix);

            BigInteger sum = FindSum(matrix, row, col, numbers, moves);

            Console.WriteLine(sum);
        }

        private static BigInteger FindSum(BigInteger[,] matrix, int inRow, int inCol, List<long> numbers, int moves)
        {
            BigInteger sum = 0;
            long startRow = matrix.GetLength(0) - 1;
            long startCol = 0;

            for (int i = 0; i < moves; i++)
            {
                long coeff = Math.Max(inRow, inCol);
                long endRow = numbers[i] / coeff;
                long endCol = numbers[i] % coeff;

                //Console.WriteLine("endRow: {0}, endCol: {1}", endRow, endCol);

                long row = startRow;
                long col = startCol;

                while (true)
                {
                    sum += matrix[row, col];
                    matrix[row, col] = 0; // doesn't add additional values

                    //Print<long>(matrix);
                    //Console.WriteLine();
                    
                    if (row == endRow && col == endCol)
                    {
                        startRow = endRow;
                        startCol = endCol;
                        break;
                    }

                    // First go to the target column
                    // Second go to the target row

                    if (col < endCol)
                    {
                        col++;
                        continue;
                    }

                    if (col > endCol)
                    {
                        col--;
                        continue;
                    }

                    if (row < endRow)
                    {
                        row++;
                        continue;
                    }

                    if (row > endRow)
                    {
                        row--;
                    }
                }
            }

            return sum;
        }

        private static BigInteger[,] FillMatrix(int row, int col)
        {
            BigInteger[,] matrix = new BigInteger[row, col];
            int power = 0;
            int step = power;

            for (int r = row - 1; r >= 0; r--)
            {
                step = power;

                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = (BigInteger)Math.Pow(2, power);
                    power++;
                }

                power = step;

                power++;
            }

            return matrix;
        }

        private static void Print<T>(T[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write("{0} ", matrix[r, c]);
                }

                Console.WriteLine();
            }
        }
    }
}