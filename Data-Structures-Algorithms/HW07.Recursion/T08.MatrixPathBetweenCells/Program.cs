using System;

namespace T08.MatrixPathBetweenCells
{
    /// <summary>
    /// 8. Modify the above program to check whether a path exists between two cells without finding all possible paths. 
    ///    Test it over an empty 100 x 100 matrix.
    /// </summary>
    public class Program
    {
        private const char ExitSymbol = 'e';
        private const char VisitedSymbol = 'v';

        private static int passablePaths;
        private static int nonPassablePaths;
        
        private static readonly char[,] matrix = new char[100, 100];
        
        private static void Main()
        {
            matrix[99, 99] = 'e';
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

            if (matrix[row, col] != default(char))
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

            matrix[row, col] = VisitedSymbol;
        }
    }
}
