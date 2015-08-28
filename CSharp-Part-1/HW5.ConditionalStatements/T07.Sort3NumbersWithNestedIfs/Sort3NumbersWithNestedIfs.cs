namespace T07.Sort3NumbersWithNestedIfs
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 7. Write a program that enters 3 real numbers and prints them sorted in descending order.
    /// Use nested if statements.
    /// Note: Don’t use arrays and the built-in sorting functionality.
    /// </summary>
    public class Sort3NumbersWithNestedIfs
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float a = ValidateInput("Enter value for a = ");
            float b = ValidateInput("Enter value for b = ");
            float c = ValidateInput("Enter value for c = ");
            float big = 0.0f;
            float middle = 0.0f;
            float small = 0.0f;

            if (a > b)
            {
                if (a > c && c > b)
                {
                    big = a;
                    middle = c;
                    small = b;
                }
                else if (a > c && c < b)
                {
                    big = a;
                    middle = b;
                    small = c;
                }
                else if (a > c && c == b)
                {
                    big = a;
                    middle = b;
                    small = c;
                }
                else
                {
                    big = c;
                    middle = a;
                    small = b;
                }
            }

            if (b > a)
            {
                if (b > c && c > a)
                {
                    big = b;
                    middle = c;
                    small = a;
                }
                else if (b > c && c < a)
                {
                    big = b;
                    middle = a;
                    small = c;
                }
                else if (b > c && c == a)
                {
                    big = b;
                    middle = c;
                    small = a;
                }
                else
                {
                    big = c;
                    middle = b;
                    small = a;
                }
            }

            if (c > b)
            {
                if (c > a && a > b)
                {
                    big = c;
                    middle = a;
                    small = b;
                }
                else if (c > a && a < b)
                {
                    big = c;
                    middle = b;
                    small = a;
                }
                else if (c > a && a == b)
                {
                    big = c;
                    middle = a;
                    small = b;
                }
            }
            else if (a == b && a == c)
            {
                Console.WriteLine("Numbers are equal.");
            }

            Console.WriteLine("Big: {0}", big);
            Console.WriteLine("Middle: {0}", middle);
            Console.WriteLine("Small: {0}", small);
        }

        private static float ValidateInput(string message)
        {
            float number;

            Console.Write(message);
            bool isValid = float.TryParse(Console.ReadLine().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = float.TryParse(Console.ReadLine().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}