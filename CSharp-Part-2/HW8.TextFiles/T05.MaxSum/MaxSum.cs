namespace T05.MaxSum
{
    using System;
    using System.IO;
    using Helper;

    /// <summary>
    /// 5. Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 
    ///    with a maximal sum of its elements. The first line in the input file contains the size of matrix N. 
    ///    Each of the next N lines contain N numbers separated by space. 
    ///    The output should be a single number in a separate text file. 
    ///
    ///    Example:
    ///    4
    ///    
    ///    2 3 3 4
    ///    0 2 3 4
    ///    3 7 1 2
    ///    4 3 3 2
    ///    
    ///    17
    /// </summary>
    public class MaxSum
    {
        public static int[,] ReadFileAndFillMatrix(string file)
        {
            StreamReader reader = new StreamReader(file);
            int[,] matrix;

            using (reader)
            {
                int number;

                string line = reader.ReadLine();

                if (int.TryParse(line, out number))
                {
                    // Fill matrix with values
                    matrix = new int[number, number];

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        int spacer = 0;
                        line = reader.ReadLine();

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[row, col] = int.Parse(line.ToString().Substring(spacer, 1));
                            spacer += 2;
                        }
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }

            return matrix;
        }

        public static void MaxSumFinder(int[,] array)
        {
            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < array.GetLength(1) - 1; col++)
                {
                    int sum = array[row, col] + array[row, col + 1] + array[row + 1, col] + array[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine("The best platform is: ");
            Console.WriteLine(" {0} {1}", array[bestRow, bestCol], array[bestRow, bestCol + 1]);
            Console.WriteLine(" {0} {1}", array[bestRow + 1, bestCol], array[bestRow + 1, bestCol + 1]);
            Console.WriteLine("The maximal sum is: {0}", bestSum);
        }

        private static void Main()
        {
            string file = @"..\..\..\Files\05.matrix.txt";
            int[,] matrix = ReadFileAndFillMatrix(file);

            Console.WriteLine("Matrix is:");
            Arrays.PrintMultiArray<int>(matrix);

            Console.WriteLine();
            MaxSumFinder(matrix);
        }
    }
}
