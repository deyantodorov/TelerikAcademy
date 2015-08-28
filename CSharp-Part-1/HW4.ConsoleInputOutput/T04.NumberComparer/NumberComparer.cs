namespace T04.NumberComparer
{
    using System;
    using System.Linq;

    public class NumberComparer
    {
        private static void Main()
        {
            int a = ReadAndValidateInput("Enter value for \"a\" = ");
            int b = ReadAndValidateInput("Enter value for \"b\" = ");

            Console.WriteLine("{0}", (a > b) ? a : b);
        }

        private static int ReadAndValidateInput(string msg)
        {
            int number;

            Console.Write(msg);

            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}