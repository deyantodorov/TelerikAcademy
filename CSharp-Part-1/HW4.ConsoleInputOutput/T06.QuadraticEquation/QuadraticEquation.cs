namespace T06.QuadraticEquation
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 6. Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
    /// 
    ///    Quadratic equation:
    ///    D greater 0, x1 = ?, x2 = ?
    ///    D = 0, x1 = x2
    ///    D less than 0, the equation 
    ///    a can't be zero & discriminant must be greater or equal to zero
    /// </summary>
    public class QuadraticEquation
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double a = ValidateInput("Enter value for a = ");
            double b = ValidateInput("Enter value for b = ");
            double c = ValidateInput("Enter value for c = ");
            double d = (b * b) - (4 * a * c);

            if (a > 0 && d >= 0)
            {
                if (d > 0)
                {
                    double x1 = (-b + Math.Sqrt(d)) / 2 * a;
                    double x2 = (-b - Math.Sqrt(d)) / 2 * a;
                    Console.WriteLine("x1 = " + x1);
                    Console.WriteLine("x2 = " + x2);
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(d)) / 2 * a;
                    Console.WriteLine("x1 = x2 = " + x1);
                }
            }
            else
            {
                Console.WriteLine("No real roots");
            }
        }

        private static double ValidateInput(string message)
        {
            double number;

            Console.Write(message);
            bool isValid = double.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = double.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}