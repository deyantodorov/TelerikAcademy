using System;

namespace T12.QueensPuzzle
{
    public class QueenSolver
    {
        private readonly byte[,] queens;
        private int counter;

        public QueenSolver(int size)
        {
            this.queens = new byte[size, size];
        }

        public int FindSolutions()
        {
            this.Solve(0);
            return this.counter;
        }

        private void Solve(int row)
        {
            if (row == this.queens.GetLength(1))
            {
                this.counter++;
                return;
            }

            for (int col = 0; col < this.queens.GetLength(0); col++)
            {
                if (this.queens[row, col] != 0)
                {
                    continue;
                }

                this.queens[row, col] += 1;
                this.MarkQeen(row, col);

                //Print();
                this.Solve(row + 1);

                this.queens[row, col] -= 1;
                this.UnMarkQueen(row, col);
            }
        }

        private void MarkQeen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(0); i++)
            {
                this.queens[i, col] += 1;

                if (col + (i - row) < this.queens.GetLength(0))
                {
                    this.queens[i, col + (i - row)] += 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] += 1;
                }
            }
        }

        private void UnMarkQueen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(0); i++)
            {
                this.queens[i, col] -= 1;

                if (col + (i - row) < this.queens.GetLength(0))
                {
                    this.queens[i, col + (i - row)] -= 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] -= 1;
                }
            }
        }

        private void Print()
        {
            for (int row = 0; row < this.queens.GetLength(0); row++)
            {
                for (int col = 0; col < this.queens.GetLength(1); col++)
                {
                    Console.Write(this.queens[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
