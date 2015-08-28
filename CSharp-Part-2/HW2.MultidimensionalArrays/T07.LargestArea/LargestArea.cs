namespace T07.LargestArea
{
    using System;
    using Helper;

    /// <summary>
    /// 7. * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. Example:
    ///    Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).
    /// </summary>
    public class LargestArea
    {
        private static void Main()
        {
            int[,] myArray = new int[,] 
            {
                { 1, 3, 2, 2, 2, 4 }, 
                { 3, 3, 3, 2, 4, 4 },
                { 4, 3, 1, 2, 3, 3 }, 
                { 4, 3, 1, 3, 3, 1 }, 
                { 4, 3, 3, 3, 1, 1 } 
            };

            bool[,] visited  = new bool[myArray.GetLength(0), myArray.GetLength(1)];

            int bestLength = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int r = 0; r < myArray.GetLength(0); r++)
            {
                for (int c = 0; c < myArray.GetLength(1); c++)
                {
                    int currentLength = DepthFirstSearch(myArray, r, c, visited);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestRow = r;
                        bestCol = c;
                    }
                }
            }

            Helper.PrintMultiArray<int>(myArray);
            Console.WriteLine("Largest area is {0} and element is {1} which starts at row {2} and col {3}", bestLength, myArray[bestRow, bestCol], bestRow, bestCol);
        }

        private static int DepthFirstSearch(int[,] matrix, int r, int c, bool[,] visited)
        {
            int result = 1;
            visited[r, c] = true;

            // Go Up
            if ((r - 1 >= 0) && (matrix[r - 1, c] == matrix[r, c]) && !visited[r - 1, c])
            {
                result += DepthFirstSearch(matrix, r - 1, c, visited);
            }

            // Go Down
            if ((r + 1 < matrix.GetLength(0)) && (matrix[r + 1, c] == matrix[r, c]) && !visited[r + 1, c])
            {
                result += DepthFirstSearch(matrix, r + 1, c, visited);
            }

            // Go Left
            if ((c - 1 >= 0) && (matrix[r, c - 1] == matrix[r, c]) && !visited[r, c - 1])
            {
                result += DepthFirstSearch(matrix, r, c - 1, visited);
            }

            // Go Right
            if ((c + 1 < matrix.GetLength(1)) && (matrix[r, c + 1] == matrix[r, c]) && !visited[r, c + 1])
            {
                result += DepthFirstSearch(matrix, r, c + 1, visited);
            }

            return result;
        }
    }
}
