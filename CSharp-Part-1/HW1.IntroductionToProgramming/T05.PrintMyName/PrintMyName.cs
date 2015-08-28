
namespace T02.PrintMyName
{
    using System;

    public class PrintMyName
    {
        /// <summary>
        /// 2. Modify the application to print your name.
        /// </summary>
        private static void Main()
        {
            // Get information and test
            Console.Write("Please, enter your name: ");
            string input = Console.ReadLine();
            bool isEmpty = string.IsNullOrEmpty(input);

            // Check if input field is empty
            while (isEmpty)
            {
                Console.Write("Please, enter your name: ");
                input = Console.ReadLine();
                isEmpty = string.IsNullOrEmpty(input);
            }

            // Print result
            Console.WriteLine("Your name is: {0}", input);
        }
    }
}
