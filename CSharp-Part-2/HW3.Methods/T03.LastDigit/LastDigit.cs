namespace T03.LastDigit
{
    using System;
    using Helper;

    /// <summary>
    /// 3. Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".
    /// </summary>
    public class LastDigit
    {
        private static void Main()
        {
            int num = Helper.ValidateInputAsInt("Eneter value: ");

            Console.WriteLine(LastDigitToText(num));
        }

        private static string LastDigitToText(int number)
        {
            int input = number % 10;
            string result = string.Empty;

            switch (input)
            {
                case 1: 
                    result = "one"; 
                    break;
                case 2: 
                    result = "two"; 
                    break;
                case 3: 
                    result = "three"; 
                    break;
                case 4: 
                    result = "four"; 
                    break;
                case 5: 
                    result = "five"; 
                    break;
                case 6: 
                    result = "six"; 
                    break;
                case 7: 
                    result = "seven"; 
                    break;
                case 8: 
                    result = "eight"; 
                    break;
                case 9: 
                    result = "nine"; 
                    break;
                default: 
                    result = "zero"; 
                    break;
            }

            return result;
        }
    }
}
