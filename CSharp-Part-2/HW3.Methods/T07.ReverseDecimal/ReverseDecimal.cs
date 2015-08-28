namespace T07.ReverseDecimal
{
    using System;
    using Helper;

    /// <summary>
    /// 7. Write a method that reverses the digits of given decimal number. Example: 256 -> 652
    /// </summary>
    public class ReverseDecimal
    {
        private static void Main()
        {
            decimal num = Helper.ValidateInputAsDecimal("Enter decimal value: ");
            Console.WriteLine(Reverse(num));
        }

        private static decimal Reverse(decimal num)
        {
            string input = num.ToString();
            bool isNegative = false;

            if (input[0] == '-')
            {
                isNegative = true;
                input = input.Replace("-", string.Empty);
            }

            char[] array = input.ToCharArray();
            Array.Reverse(array);

            input = string.Empty;
            input = new string(array);
            string tempResult = string.Empty;

            if (isNegative)
            {
                tempResult = "-" + input;                
            }
            else
            {
                tempResult = input;
            }

            decimal result = decimal.Parse(tempResult);

            return result;
        }
    }
}
