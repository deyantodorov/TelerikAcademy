using System;

namespace T09.LargestConnectedArea
{
    /// <summary>
    /// 9. Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
    /// </summary>
    public class Program
    {
        private static int largestArea = 0;

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

            Console.WriteLine("Largest area is: " + largestArea);
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
                if (steps > largestArea)
                {
                    largestArea = steps;
                }

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
