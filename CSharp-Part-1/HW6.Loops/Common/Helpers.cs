namespace Common
{
    using System;
    using System.Numerics;

    public class Helpers
    {
        public static int ValidateInputAsInt(string message)
        {
            int number;

            Console.Write(message);
            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static uint ValidateInputAsUint(string message)
        {
            uint number;

            Console.Write(message);
            bool isValid = uint.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = uint.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static double ValidateInputAsDouble(string message)
        {
            double number;

            Console.Write(message);
            bool isValid = double.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = double.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static long ValidateInputAsLong(string message)
        {
            long number;

            Console.Write(message);
            bool isValid = long.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = long.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static decimal CalcFactorial(uint count)
        {
            decimal factorial = 1;
            for (int i = 1; i <= count; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static BigInteger CalcFactorialBigInteger(uint count)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= count; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static int NumberToPower(int number, int power)
        {
            int n = number;
            int p = power;
            int result = 1;
            for (int i = 0; i < p; i++)
            {
                result *= n;
            }
            return result;
        }
    }
}
