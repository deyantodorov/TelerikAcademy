namespace T02.BonusScore
{
    using System;
    using System.Linq;

    /// <summary>
    /// 2. Write a program that applies bonus score to given score in the range [1…9] by the following rules:
    ///    If the score is between 1 and 3, the program multiplies it by 10.
    ///    If the score is between 4 and 6, the program multiplies it by 100.
    ///    If the score is between 7 and 9, the program multiplies it by 1000.
    ///    If the score is 0 or more than 9, the program prints “invalid score”.
    /// </summary>
    public class BonusScore
    {
        private static void Main()
        {
            int score = ValidateInput("Score: ");
            string message = string.Empty;

            if (score >= 1 && score <= 3)
            {
                message = (score * 10).ToString();
            }
            else if (score >= 4 && score <= 6)
            {
                message = (score * 100).ToString();
            }
            else if (score >= 7 && score <= 9)
            {
                message = (score * 1000).ToString();
            }
            else
            {
                message = "invalid score";
            }

            Console.WriteLine(message);
        }

        private static int ValidateInput(string message)
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
    }
}