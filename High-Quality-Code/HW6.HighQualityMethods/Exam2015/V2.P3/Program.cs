namespace V2.P3
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        private static void Main()
        {
            var dimentions = Console.ReadLine().Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            int row = dimentions[0];
            int col = dimentions[1];
            int moves = int.Parse(Console.ReadLine());
            long[,] matrix = FillMatrix(row, col);
            //Print<BigInteger>(matrix);

            int r = matrix.GetLength(0) - 1;
            int c = 0;

            BigInteger sum = 0;

            for (int move = 0; move < moves; move++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var direction = command[0];
                var stepNumber = int.Parse(command[1]);
                int stepCount = 0;

                while (true)
                {
                    if (stepCount == stepNumber)
                    {
                        break;
                    }

                    sum += matrix[r, c];
                    matrix[r, c] = 0;
                    stepCount++;

                    //Print<long>(matrix);

                    if (stepCount == stepNumber)
                    {
                        break;
                    }

                    if (direction == "RU" || direction == "UR")
                    {
                        // up-right
                        r--;
                        c++;

                        if (r < 0 || c > matrix.GetLength(1) - 1)
                        {
                            // Go back
                            r++;
                            c--;
                            break;
                        }

                        continue;
                    }

                    if (direction == "LU" || direction == "UL")
                    {
                        // up-left
                        r--;
                        c--;

                        if (r < 0 || c < 0)
                        {
                            // Go back
                            r++;
                            c++;
                            break;
                        }

                        continue;
                    }

                    if (direction == "DL" || direction == "LD")
                    {
                        // down-left
                        r++;
                        c--;

                        if (r > matrix.GetLength(0) - 1 || c < 0)
                        {
                            // Go back
                            r--;
                            c++;
                            break;
                        }

                        continue;
                    }

                    if (direction == "RD" || direction == "DR")
                    {
                        // down-right
                        r++;
                        c++;

                        if (r > matrix.GetLength(0) - 1 || c > matrix.GetLength(1) - 1)
                        {
                            // Go back
                            r--;
                            c--;
                            break;
                        }

                        continue;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static long[,] FillMatrix(int row, int col)
        {
            long[,] matrix = new long[row, col];
            long power = 0;
            long step = 3;

            for (int r = row - 1; r >= 0; r--)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = power * step;
                    power++;
                }

                power = row - r;
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

            Console.WriteLine();
        }
    }
}
