using System;

namespace T07.Matrix
{
    /// <summary>
    /// 7. We are given a matrix of passable and non-passable cells.
    ///    Write a recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    public class Program
    {
        private const char ExitSymbol = 'e';
        private const char VisitedSymbol = 'v';
        private static char BlankSymbol = ' ';

        private static int passablePaths;
        private static int nonPassablePaths;

        private static readonly char[,] matrix =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        private static void Main()
        {
            FindPaths(0, 0);

            Console.WriteLine("Passable paths: " + passablePaths);
            Console.WriteLine("Non-passable paths: " + nonPassablePaths);
        }

        private static void FindPaths(int row, int col)
        {
            FindExit(row, col);
        }

        private static void FindExit(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                // Out of matrix
                return;
            }

            if (matrix[row, col] == ExitSymbol)
            {
                // exit found
                passablePaths++;
                return;
            }

            if (matrix[row, col] != BlankSymbol)
            {
                // can't continue no path
                nonPassablePaths++;
                return;
            }

            matrix[row, col] = VisitedSymbol;

            FindExit(row - 1, col); //go up
            FindExit(row, col + 1); // go right
            FindExit(row + 1, col); // go down
            FindExit(row, col - 1); // go left

            matrix[row, col] = BlankSymbol;
        }
    }
}
