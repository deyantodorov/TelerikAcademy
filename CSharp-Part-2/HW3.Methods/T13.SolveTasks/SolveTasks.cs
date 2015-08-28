namespace T13.SolveTasks
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Helper;

    /// <summary>
    /// 13. Write a program that can solve these tasks:
    ///     Reverses the digits of a number
    ///     Calculates the average of a sequence of integers
    ///     Solves a linear equation a * x + b = 0
    ///     Create appropriate methods.
    ///     Provide a simple text-based menu for the user to choose which task to solve.
    ///     Validate the input data:
    ///     The decimal number should be non-negative
    ///     The sequence should not be empty
    ///     a should not be equal to 0
    /// </summary>
    public class SolveTasks
    {
        private static void Main()
        {
            RunMenu();
        }

        private static void RunMenu()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("What you would like to do? Please choose one of three options: ");
            Console.WriteLine("1. Reverses the digits of a number - press 1");
            Console.WriteLine("2. Calculates the average of a sequence of integers - press 2");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0 - press 3");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine();
            string choice = Console.ReadLine();

            byte yourChoice = ChoiceValidator(choice);

            if (yourChoice == 1)
            {
                decimal input = Helper.ValidateInputAsDecimal("Enter some value: ");
                decimal output = Reverser(input);
                Console.WriteLine(output);
            }
            else if (yourChoice == 2)
            {
                int arrayLength = Helper.ValidateInputAsInt("How long will be your sequence: ");
                int[] array = new int[arrayLength];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Helper.ValidateInputAsInt("Enter value: ");
                }

                decimal result = Average(array);
                Console.WriteLine("Average is {0}", result);
            }
            else if (yourChoice == 3)
            {
                Console.WriteLine("Enter the coefficients of the equation:");
                decimal a = Helper.ValidateInputAsDecimal("a = ");
                decimal b = Helper.ValidateInputAsDecimal("b = ");

                if (a == 0.0m && b != 0.0m)
                {
                    Console.WriteLine("The equation can't be solved because a = 0 and b != 0");
                }
                else if (a == 0.0m && b == 0.0m)
                {
                    Console.WriteLine("Every x is solution to the equation.");
                }
                else
                {
                    decimal result = LinearEquation(a, b);
                    Console.WriteLine("The root x = {0}", result);
                }
            }
        }

        private static decimal LinearEquation(decimal a, decimal b)
        {
            decimal result = -b / a;
            return result;
        }

        private static decimal Reverser(decimal value)
        {
            string input = value.ToString();
            char[] temp = input.ToCharArray();

            Array.Reverse(temp);

            string output = new string(temp);

            return Convert.ToDecimal(output);
        }

        private static decimal Average(int[] array)
        {
            decimal result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            result = result / array.Length;
            return result;
        }

        private static byte ChoiceValidator(string choice)
        {
            byte userChoice = 0;

            bool isValid = byte.TryParse(choice, out userChoice);

            while (!isValid || (userChoice < 0 || userChoice > 3))
            {
                Console.WriteLine("Invalid number! Enter 1, 2 or 3");
                isValid = byte.TryParse(Console.ReadLine(), out userChoice);
            }

            return userChoice;
        }
    }
}