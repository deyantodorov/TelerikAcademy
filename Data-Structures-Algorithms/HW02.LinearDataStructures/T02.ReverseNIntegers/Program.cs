namespace T02.ReverseNIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 2.  Write a program that reads N integers from the console and reverses them using a stack.
    ///     Use the Stack<int> class.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var numbers = ReadInput();

            Console.WriteLine("Entered: " + string.Join(", ", numbers));
            Console.WriteLine("Reversed: " + string.Join(", ", numbers.Reverse()));
        }

        private static Stack<int> ReadInput()
        {
            var result = new Stack<int>();

            var line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                int number;

                if (int.TryParse(line, out number))
                {
                    number = int.Parse(line);
                    result.Push(number);
                }

                line = Console.ReadLine();
            }

            return result;
        }
    }
}
