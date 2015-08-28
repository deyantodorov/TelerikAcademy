namespace T03.LongestSequence
{
    using System;
    using Helper;

    /// <summary>
    /// 3. We are given a matrix of strings of size N x M. 
    ///    Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
    ///    Write a program that finds the longest sequence of equal strings in the matrix. 
    /// </summary>
    public class LongestSequence
    {
        private static void Main()
        {
            string[,] testArray1 = 
            {
                { "ha", "fifi", "ho", "hi" },
                { "fo", "ha", "hi", "xx" },
                { "xxx", "ho", "ha", "xx" }
            };

            string[] result = FindLongest(testArray1, 0, 0);

            Helper.PrintMultiArray<string>(testArray1);
            
            Console.Write("Result: ");
            for (int i = 0; i < int.Parse(result[0]); i++)
            {
                Console.Write("{0} ", result[1]);
            }

            Console.WriteLine();
            Console.WriteLine();

            string[,] testArray2 =
            {
              { "s", "qq", "s" },
              { "pp", "pp", "s" },
              { "pp", "qq", "s" },
            };

            string[] result2 = FindLongest(testArray2, 0, 0);

            Helper.PrintMultiArray<string>(testArray2);

            Console.Write("Result: ");
            for (int i = 0; i < int.Parse(result2[0]); i++)
            {
                Console.Write("{0} ", result2[1]);
            }

            Console.WriteLine();
        }

        private static string[] FindLongest(string[,] matrix, int row, int col)
        {
            int maxLength = 1;
            string maxString = string.Empty;

            // Find biggest in eight directions - Right, Right Up, Rigth Down, Down, Left, Left Up, Left Down, Up
            for (int r = row; r < matrix.GetLength(0); r++)
            {
                int currentLength = 1;

                for (int c = col; c < matrix.GetLength(1); c++)
                {
                    // Right
                    currentLength = FindPath(matrix, r, c, "R");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Right Up
                    currentLength = FindPath(matrix, r, c, "RU");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Right Down
                    currentLength = FindPath(matrix, r, c, "RD");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Down
                    currentLength = FindPath(matrix, r, c, "D");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Left
                    currentLength = FindPath(matrix, r, c, "L");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Left Down
                    currentLength = FindPath(matrix, r, c, "LD");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Left Up
                    currentLength = FindPath(matrix, r, c, "LU");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }

                    // Up
                    currentLength = FindPath(matrix, r, c, "U");

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxString = matrix[r, c];
                    }
                }
            }

            string[] result = new string[2];
            result[0] = maxLength.ToString();
            result[1] = maxString;

            return result;
        }

        private static int FindPath(string[,] matrix, int row, int col, string direction)
        {
            int r = row;
            int c = col;
            string symbol = matrix[row, col];

            int maxLength = 0;

            if (direction == "R")
            {
                c++;

                if (c >= matrix.GetLength(1) || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (c < matrix.GetLength(1) && matrix[r, c] == symbol)
                    {
                        c++;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "RU")
            {
                r--;
                c++;

                if (r < 0 || c >= matrix.GetLength(1) || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r >= 0 && c < matrix.GetLength(1) && matrix[r, c] == symbol)
                    {
                        r--;
                        c++;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "RD")
            {
                r++;
                c++;

                if (r >= matrix.GetLength(0) || c >= matrix.GetLength(1) || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r < matrix.GetLength(0) && c < matrix.GetLength(1) && matrix[r, c] == symbol)
                    {
                        r++;
                        c++;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "D")
            {
                r++;

                if (r >= matrix.GetLength(0) || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r < matrix.GetLength(0) && matrix[r, c] == symbol)
                    {
                        r++;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "L")
            {
                c--;

                if (c < 0 || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (c >= 0 && matrix[r, c] == symbol)
                    {
                        c--;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "LU")
            {
                r--;
                c--;

                if (r < 0 || c < 0 || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r >= 0 && c >= 0 && matrix[r, c] == symbol)
                    {
                        r--;
                        c--;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "LD")
            {
                r++;
                c--;

                if (r >= matrix.GetLength(0) || c < 0 || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r < matrix.GetLength(0) && c >= 0 && matrix[r, c] == symbol)
                    {
                        r++;
                        c--;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }
            else if (direction == "U")
            {
                r--;

                if (r <= 0 || matrix[r, c] != symbol)
                {
                    return 0;
                }
                else
                {
                    int currentLength = 1;

                    while (r >= 0 && matrix[r, c] == symbol)
                    {
                        r--;
                        currentLength++;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }

            return maxLength;
        }
    }
}
