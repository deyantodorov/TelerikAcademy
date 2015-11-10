using System;

namespace T10.AllPaths
{
    /// <summary>
    /// 10. We are given a matrix of passable and non-passable cells.
    ///     Write a recursive program for finding all areas of passable cells in the matrix.
    /// </summary>
    public class Program
    {
        private static int passablePaths = 0;

        private static readonly char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        private static void Main()
        {
            FindPaths(0, 0, 0);
        }

        private static void FindPaths(int row, int col, int steps)
        {
            FindExit(row, col, steps);
        }

        private static void FindExit(int row, int col, int steps)
        {
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                passablePaths++;

                Console.WriteLine("Path: {0}, Steps: {1}", passablePaths, steps);

                return;
            }

            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 'v';

            FindExit(row - 1, col, steps + 1); // up
            FindExit(row, col + 1, steps + 1); // right
            FindExit(row + 1, col, steps + 1); // down
            FindExit(row, col - 1, steps + 1); // left

            lab[row, col] = ' ';
        }
    }
}
