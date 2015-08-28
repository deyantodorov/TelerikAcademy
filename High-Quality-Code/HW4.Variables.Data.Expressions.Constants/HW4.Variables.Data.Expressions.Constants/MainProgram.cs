namespace HW5.Variables.Data.Expressions.Constants
{
    using System;

    public class MainProgram
    {
        private static void Main()
        {
            // Testing Task 1:
            Size car = new Size(2.34, 4.65);
            Size car2 = Size.GetRotatedSize(car, 90.1);

            Console.WriteLine(car);
            Console.WriteLine(car2);

            // Testing Task 2: 
            double[] digits = new double[] { 22.2, 2, 22, 3, 4, 5, 6, 7, 1, 8 };

            Console.WriteLine("Average: " + Statistics.GetAvg(digits, digits.Length));
            Console.WriteLine("Min: " + Statistics.GetMin(digits, digits.Length));
            Console.WriteLine("Max: " + Statistics.GetMax(digits, digits.Length));
        }
    }
}
