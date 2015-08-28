namespace T01.PrintMatrix
{
    using System;
    using Helper;

    /// <summary>
    /// 1. Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
    /// </summary>
    public class PrintMatrix
    {
        private static void Main()
        {
            int n = Helper.ValidateInputAsInt("Enter value: ");

            if (n > 0)
            {
                int[,] array = new int[n, n];

                // A
                ArrayVarA(ref array, n);
                Console.WriteLine();
                Console.WriteLine("Variant A: ");
                Helper.PrintMultiArray<int>(array);
                Console.WriteLine();

                // B
                ArrayVarB(ref array, n);
                Console.WriteLine("Variant B: ");
                Helper.PrintMultiArray<int>(array);
                Console.WriteLine();

                // C
                ArrayVarC(ref array, n);
                Console.WriteLine("Variant C: ");
                Helper.PrintMultiArray<int>(array);
                Console.WriteLine();

                // C
                ArrayVarD(ref array, n);
                Console.WriteLine("Variant D: ");
                Helper.PrintMultiArray<int>(array);
            }
            else
            {
                Console.WriteLine("No matrix");
            }
        }

        private static void ArrayVarA(ref int[,] array, int n)
        {
            int index = 1;

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    array[row, col] = index;
                    index++;
                }
            }
        }

        private static void ArrayVarB(ref int[,] array, int n)
        {
            int index = 1;
            bool isTop = true;

            for (int col = 0; col < n; col++)
            {
                if (isTop)
                {
                    for (int row = 0; row < n; row++)
                    {
                        array[row, col] = index;
                        index++;
                    }

                    isTop = false;
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        array[row, col] = index;
                        index++;
                    }

                    isTop = true;
                }
            }
        }

        private static void ArrayVarC(ref int[,] array, int n)
        {
            if (n == 1)
            {
                return;
            }

            int index = 1;
            int row = n - 1;
            int prevRow;

            int col = 0;
            int prevCol;

            bool swap = true;
            bool finish = true;

            while (finish)
            {
                prevRow = row;
                prevCol = col;

                while (row <= n - 1 && col <= n - 1)
                {
                    array[row, col] = index;

                    index++;
                    row++;
                    col++;
                }

                row = prevRow;
                col = prevCol;

                if (swap)
                {
                    row--;
                    col = 0;

                    if (row < 0)
                    {
                        row = 0;
                        col = 1;
                        swap = false;
                    }
                }
                else
                {
                    col++;
                    row = 0;
                }

                if (row == 0 && col == n - 1)
                {
                    array[row, col] = index;
                    finish = false;
                }
            }
        }

        private static void ArrayVarD(ref int[,] array, int n)
        {
            Array.Clear(array, 0, array.Length);
            string direction = "down";
            string lastDirection = "down";

            int row = 0;
            int col = 0;
            int index = 1;
            int final = n * n;

            while (index <= final)
            {
                if (direction == "down")
                {
                    array[row, col] = index;
                    row++;

                    if (row == n || array[row, col] != 0)
                    {
                        direction = "right";
                        row--;
                        col++;

                        lastDirection = "down";
                    }
                }
                else if (direction == "right")
                {
                    array[row, col] = index;
                    col++;

                    if (col == n || array[row, col] != 0)
                    {
                        direction = "up";
                        col--;
                        row--;

                        lastDirection = "right";
                    }
                }
                else if (direction == "up")
                {
                    array[row, col] = index;
                    row--;

                    if (row < 0 || array[row, col] != 0)
                    {
                        direction = "left";
                        row++;
                        col--;

                        lastDirection = "up";
                    }
                }
                else if (direction == "left")
                {
                    array[row, col] = index;
                    col--;

                    if ((col < 0 || array[row, col] != 0) && lastDirection == "up")
                    {
                        direction = "down";
                        col++;
                        row++;

                        lastDirection = "left";
                    }
                }

                index++;
            }
        }
    }
}
