namespace T06.Max20Chars
{
    using System;

    /// <summary>
    /// 6. Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, 
    ///    the rest of the characters should be filled with '*'. Print the result string into the console.
    /// </summary>
    public class Max20Chars
    {
        private static void Main()
        {
            Console.Write("Enter something (max length 20 chars): ");
            string input = Console.ReadLine();

            while (input.Length > 20)
            {
                Console.Write("Max length must be 20 chars: Enter new one: ");
                input = Console.ReadLine();
            }

            if (input.Length < 20)
            {
                input = input.PadRight(20, '*');
            }

            Console.WriteLine("Result is: {0}", input);
        }
    }
}
