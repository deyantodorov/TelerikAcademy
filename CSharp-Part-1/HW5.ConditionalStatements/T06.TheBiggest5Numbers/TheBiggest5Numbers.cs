namespace T06.TheBiggest5Numbers
{
    using System;

    /// <summary>
    /// 6. Write a program that finds the biggest of five numbers by using only five if statements.
    /// </summary>
    public class TheBiggest5Numbers
    {
        private static void Main()
        {
            float a = ValidateInput("Enter value for a = ");
            float b = ValidateInput("Enter value for b = ");
            float c = ValidateInput("Enter value for c = ");
            float d = ValidateInput("Enter value for d = ");
            float e = ValidateInput("Enter value for e = ");
            float biggestNumber = default(float);

            if (a >= b && a >= c && a >= d && a >= e)
            {
                biggestNumber = a;
            }

            if (b >= a && b >= c && b >= d && b >= e)
            {
                biggestNumber = b;
            }

            if (c >= b && c >= a && c >= d && c >= e)
            {
                biggestNumber = c;
            }

            if (d >= b && d >= c && d >= a && d >= e)
            {
                biggestNumber = d;
            }

            if (e >= b && e >= c && e >= d && e >= a)
            {
                biggestNumber = e;
            }

            Console.WriteLine(biggestNumber);
        }

        private static float ValidateInput(string message)
        {
            float number;

            Console.Write(message);
            bool isValid = float.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = float.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}