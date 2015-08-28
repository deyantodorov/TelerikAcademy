namespace Helper
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Helper class for different methods
    /// </summary>
    public class Helper
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

        public static decimal ValidateInputAsDecimal(string message)
        {
            decimal number;

            Console.Write(message);
            bool isValid = decimal.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = decimal.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
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

        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        public static void PrintMultiArray<T>(T[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write("{0} ", array[row, col].ToString().PadLeft(2));
                }

                Console.WriteLine();
            }
        }
    }
}
