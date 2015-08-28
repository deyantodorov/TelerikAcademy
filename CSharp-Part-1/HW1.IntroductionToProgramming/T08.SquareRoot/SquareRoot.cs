namespace T08.SquareRoot
{
    using System;

    /// <summary>
    /// 8. Create a console application that calculates and prints the square root of the number 12345.
    /// </summary>
    public class SquareRoot
    {
        private static void Main()
        {
            int number = 12345;
            Console.WriteLine("Square of the number {0} is {1}", number, Math.Sqrt(number));
        }
    }
}
