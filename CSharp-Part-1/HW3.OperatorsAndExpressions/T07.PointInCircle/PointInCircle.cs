namespace T07.PointInCircle
{
    using System;
    using System.Linq;

    /// <summary>
    /// 7. Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
    /// </summary>
    public class PointInCircle
    {
        private static void Main()
        {
            int x = ReadAndValidateInput("Please enter value for X = ");
            int y = ReadAndValidateInput("Please enter value for Y = ");
            const int K = 2;

            int circle = (x * x) + (y * y);

            if (circle <= K * K)
            {
                Console.WriteLine("Points (x = {0}, y = {1}) are in circle K(O, 2)", x, y);
            }
            else
            {
                Console.WriteLine("Points (x = {0}, y = {1}) are outside of circle K(O, 2)", x, y);
            }
        }

        /// <summary>
        /// Read and validate user input as integer
        /// </summary>
        /// <param name="msg">input message</param>
        /// <returns>int result</returns>
        private static int ReadAndValidateInput(string msg)
        {
            int number = 0;

            Console.Write(msg);

            bool isValidIntegerWidth = int.TryParse(Console.ReadLine(), out number);
            while (isValidIntegerWidth == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValidIntegerWidth = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}