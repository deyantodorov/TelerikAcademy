using System;

namespace T12.QueensPuzzle
{
    /// <summary>
    /// 12. *Write a recursive program to solve the "8 Queens Puzzle" with backtracking.
    ///     Learn more at: wiki/Eight queens puzzle
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var queen = new QueenSolver(8);
            Console.WriteLine("Solutions: " + queen.FindSolutions());
        }
    }
}
