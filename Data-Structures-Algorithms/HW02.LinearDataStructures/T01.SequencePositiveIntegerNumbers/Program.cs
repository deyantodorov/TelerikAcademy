namespace T01.SequencePositiveIntegerNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 1. Write a program that reads from the console a sequence of positive integer numbers.
    ///    The sequence ends when empty line is entered.
    ///    Calculate and print the sum and average of the elements of the sequence.
    ///    Keep the sequence in List<int>.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var list = ReadInput();

            Console.WriteLine("You entered: " + string.Join(", ", list));

            Console.WriteLine("Sum is: " + list.Sum());
            Console.WriteLine("Avg is: " + list.Average());
        }

        private static List<int> ReadInput()
        {
            var result = new List<int>();

            var line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                int number;

                if (int.TryParse(line, out number))
                {
                    number = int.Parse(line);

                    if (number > 0)
                    {
                        result.Add(number);
                    }
                }

                line = Console.ReadLine();
            }

            return result;
        }
    }
}
