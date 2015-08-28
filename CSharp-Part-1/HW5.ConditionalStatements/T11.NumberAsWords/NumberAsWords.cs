namespace T11.NumberAsWords
{
    using System;
    using System.Linq;

    /// <summary>
    /// 11. Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
    /// </summary>
    public class NumberAsWords
    {
        private static void Main()
        {
            int number = ValidateInput("Enter number between 0 to 999: ");

            string numberToWords = ConvertNumberToText(number);

            Console.WriteLine(numberToWords);
        }

        private static int ValidateInput(string message)
        {
            int number;

            Console.Write(message);
            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false || number > 1000000)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        private static string ConvertNumberToText(int number)
        {
            if (number == 0)
            {
                return "zero";
            }

            string words = string.Empty;

            if (number / 1000000 > 0)
            {
                words += ConvertNumberToText(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += ConvertNumberToText(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += ConvertNumberToText(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != string.Empty)
                {
                    words += "and ";
                }

                string[] zeroToNineteen = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                string[] zeroToNinety = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += zeroToNineteen[number];
                }
                else
                {
                    words += zeroToNinety[number / 10];
                    if (number % 10 > 0)
                    {
                        words += "-" + zeroToNineteen[number % 10];
                    }
                }
            }

            return words;
        }
    }
}