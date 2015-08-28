namespace T04.MultiplicationSign
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 4. Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators.
    /// </summary>
    public class MultiplicationSign
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float[] numbers = new float[3];
            int negative = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ValidateInput("Enter real number = ");

                if (numbers[i] < 0)
                {
                    negative++;
                }
            }

            if (numbers[0] == 0 || numbers[1] == 0 || numbers[2] == 0)
            {
                Console.WriteLine("Product is 0");
            }
            else if (negative == 1 || negative == 3)
            {
                Console.WriteLine("Product of ({0}) * ({1}) * ({2}) is negative", numbers[0], numbers[1], numbers[2]);
            }
            else
            {
                Console.WriteLine("Product of ({0}) * ({1}) * ({2}) is positive", numbers[0], numbers[1], numbers[2]);
            }
        }

        private static float ValidateInput(string message)
        {
            float number;

            Console.Write(message);
            bool isValid = float.TryParse(Console.ReadLine().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = float.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}