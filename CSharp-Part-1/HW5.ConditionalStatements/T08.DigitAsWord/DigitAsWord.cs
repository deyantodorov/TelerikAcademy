namespace T08.DigitAsWord
{
    using System;
    using System.Linq;

    /// <summary>
    /// 8. Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
    ///    Print “not a digit” in case of invalid input.
    ///    Use a switch statement.
    /// </summary>
    public class DigitAsWord
    {
        private static void Main()
        {
            Console.WriteLine("Enter digit (0-9): ");
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    {
                        Console.WriteLine("One");
                        break;
                    }

                case "2":
                    {
                        Console.WriteLine("Two");
                        break;
                    }

                case "3":
                    {
                        Console.WriteLine("Three");
                        break;
                    }

                case "4":
                    {
                        Console.WriteLine("Four");
                        break;
                    }

                case "5":
                    {
                        Console.WriteLine("Five");
                        break;
                    }

                case "6":
                    {
                        Console.WriteLine("Six");
                        break;
                    }

                case "7":
                    {
                        Console.WriteLine("Seven");
                        break;
                    }

                case "8":
                    {
                        Console.WriteLine("Eight");
                        break;
                    }

                case "9":
                    {
                        Console.WriteLine("Nine");
                        break;
                    }
                case "0":
                    {
                        Console.WriteLine("Zero");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("not a digit");
                        break;
                    }
            }
        }
    }
}