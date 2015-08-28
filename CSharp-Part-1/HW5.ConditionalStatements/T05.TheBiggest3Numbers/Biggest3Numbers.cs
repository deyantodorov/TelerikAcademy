namespace T05.TheBiggest3Numbers
{
    using System;
    using System.Linq;

    /// <summary>
    /// 5. Write a program that finds the biggest of three numbers.
    /// </summary>
    public class Biggest3Numbers
    {
        private static void Main()
        {
            float a = ValidateInput("Enter value for a = ");
            float b = ValidateInput("Enter value for b = ");
            float c = ValidateInput("Enter value for c = ");
            float biggestNumber = a;

            if (b > biggestNumber && b > c)
            {
                biggestNumber = b;
                Console.WriteLine("Bigger number is b = {0}", b);
            }
            else if (c > biggestNumber && c > b)
            {
                biggestNumber = c;
                Console.WriteLine("Bigger number is c = {0}", c);
            }
            else if (a == b && a == c)
            {
                Console.WriteLine("Numbers are equal.");
            }
            else
            {
                Console.WriteLine("Bigger number is a = {0}", a);
            }
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