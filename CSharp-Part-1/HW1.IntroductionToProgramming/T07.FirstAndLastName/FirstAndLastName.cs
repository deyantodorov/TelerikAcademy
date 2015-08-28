namespace T07.FirstAndLastName
{
    using System;

    /// <summary>
    /// 7. Create console application that prints your first and last name.
    /// </summary>
    public class FirstAndLastName
    {
        private static void Main()
        {
            string firstName = ReadAndValidate("Enter your first name: ");
            string lastName = ReadAndValidate("Enter your last name: ");

            Console.WriteLine("Your name: {0} {1}", firstName, lastName);
        }

        /// <summary>
        /// Read and validation method
        /// </summary>
        private static string ReadAndValidate(string message)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.Write(message);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
