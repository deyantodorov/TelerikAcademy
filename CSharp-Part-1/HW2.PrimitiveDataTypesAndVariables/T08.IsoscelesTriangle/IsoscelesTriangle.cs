namespace T08.IsoscelesTriangle
{
    using System;

    /// <summary>
    /// 8. Write a program that prints an isosceles triangle of 9 copyright symbols ©
    ///   © 
    ///  ©©©
    /// ©©©©©
    /// </summary>
    public class IsoscelesTriangle
    {
        private static void Main()
        {
            byte number = 9;
            char symbol = '\u00A9';
            byte height = (byte)Math.Sqrt(number);

            for (int row = 0; row < height; row++)
            {
                Console.CursorLeft = height - row;
                for (int col = 0; col <= 2 * row; col++)
                {
                    Console.Write(symbol);
                }

                Console.WriteLine();
            }
        }
    }
}