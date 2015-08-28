namespace T02.PrintCompanyInformation
{
    using System;
    using System.Linq;

    /// <summary>
    /// 2. A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
    ///    Write a program that reads the information about a company and its manager and prints it back on the console.
    /// </summary>
    public class PrintCompanyInformation
    {
        private static void Main()
        {
            string companyName = TextInput("Enter \"Company name\": ");
            string companyAddress = TextInput("Enter \"Company address\": ");
            string companyPhone = TextInput("Enter \"Phone number\": ");
            string companyFax = TextInput("Enter \"Fax number\": ");
            string companyWebsite = TextInput("Enter \"Web site\": ");
            string managerFirstName = TextInput("Enter \"Manager first name\": ");
            string managerLastName = TextInput("Enter \"Manager last name\": ");
            byte managerAge = ValidateInput("Enter \"Manager age\": ");
            string managerPhone = TextInput("Enter \"Manager phone\": ");

            Console.WriteLine();
            Console.WriteLine("Company name: {0}", companyName);
            Console.WriteLine("Company address: {0}", companyAddress);
            Console.WriteLine("Phone number: {0}", companyPhone);
            Console.WriteLine("Fax number: {0}", companyFax);
            Console.WriteLine("Web site: {0}", companyWebsite);
            Console.WriteLine("Manager first name: {0}", managerFirstName);
            Console.WriteLine("Manager last name: {0}", managerLastName);
            Console.WriteLine("Manager age: {0}", managerAge);
            Console.WriteLine("Manager phone: {0}", managerPhone);
        }

        private static string TextInput(string message)
        {
            Console.Write(message);
            string textInput = Console.ReadLine();

            while (string.IsNullOrEmpty(textInput))
            {
                Console.Write("Error! {0}", message);
                textInput = Console.ReadLine();
            }

            return textInput;
        }

        private static byte ValidateInput(string message)
        {
            byte number;

            Console.Write(message);
            bool isValid = byte.TryParse(Console.ReadLine(), out number);

            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = byte.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}