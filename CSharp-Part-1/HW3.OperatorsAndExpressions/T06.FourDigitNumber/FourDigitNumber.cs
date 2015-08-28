namespace T06.FourDigitNumber
{
    using System;
    using System.Linq;

    /// <summary>
    /// 6. Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
    //     Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
    //     Prints on the console the number in reversed order: dcba (in our example 1102).
    //     Puts the last digit in the first position: dabc (in our example 1201).
    //     Exchanges the second and the third digits: acbd (in our example 2101).
    //     The number has always exactly 4 digits and cannot start with 0.
    /// </summary>
    public class FourDigitNumber
    {
        private static void Main()
        {
            string input = ReadInput();

            Console.WriteLine(GetSum(input));
            Console.WriteLine(Reversed(input));
            Console.WriteLine(LastToFirst(input));
            Console.WriteLine(ExchangeSecondAndThird(input));
        }

        private static string ExchangeSecondAndThird(string input)
        {
            char[] array = input.ToArray();
            string result = array[0].ToString() + array[2].ToString() + array[1].ToString() + array[3].ToString();

            return result;
        }

        private static string LastToFirst(string input)
        {
            char[] array = input.ToArray();
            string result = array[array.Length - 1].ToString() + array[0] + array[1] + array[2];

            return result;
        }

        private static string Reversed(string input)
        {
            char[] array = input.ToArray();
            Array.Reverse(array);

            return new string(array);
        }

        private static string GetSum(string input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += int.Parse(input[i].ToString());
            }

            return sum.ToString();
        }

        private static string ReadInput()
        {
            Console.Write("Write four digit number. Cannot start with 0: ");
            string result = Console.ReadLine();

            while (result.Length != 4 || result[0] == 0)
            {
                Console.Write("Write four digit number. Cannot start with 0: ");
                result = Console.ReadLine();
            }

            return result;
        }
    }
}