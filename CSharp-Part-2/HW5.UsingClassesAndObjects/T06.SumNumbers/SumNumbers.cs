namespace T06.SumNumbers
{
    using System;

    /// <summary>
    /// 6. You are given a sequence of positive integer values written into a string, separated by spaces. 
    ///    Write a function that reads these values from given string and calculates their sum. 
    ///    Example: string = "43 68 9 23 318" -> result = 461
    /// </summary>
    public class SumNumbers
    {
        public static int CalcSum(string input)
        {
            int result = 0;

            string[] inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in inputArray)
            {
                result += int.Parse(item);
            }

            return result;
        }

        private static void Main()
        {
            string input = "43 68 9 23 318";
            int result = CalcSum(input);
            Console.WriteLine("Sum of \"{0}\" is {1}", input, result);
        }
    }
}
