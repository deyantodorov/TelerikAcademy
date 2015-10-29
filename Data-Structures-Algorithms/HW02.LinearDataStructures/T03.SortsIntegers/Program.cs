namespace T03.SortsIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 3. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var numbers = ReadInput();

            Console.WriteLine("Entered: " + string.Join(", ", numbers));

            numbers.Sort();

            Console.WriteLine("Sorted increasing: " + string.Join(", ", numbers));
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
                    result.Add(number);
                }

                line = Console.ReadLine();
            }

            return result;
        }
    }
}
