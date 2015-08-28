namespace T07.FromAnyNumeralSystem
{
    using System;
    using Helper;

    /// <summary>
    /// 7. Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
    /// </summary>
    public class FromAnyNumeralSystem
    {
        private static void Main()
        {
            // Your could test here: http://www.cleavebooks.co.uk/scol/calnumba.htm
            Console.Write("Enter positive value to convert: ");
            string input = Console.ReadLine().ToUpper();

            Console.Write("s (base from): ");
            int baseFrom = int.Parse(Console.ReadLine());

            Console.Write("d (base to): ");
            int baseTo = int.Parse(Console.ReadLine());

            long inputToDec = NumSys.FromAnyTo10(input, baseFrom);
            Console.WriteLine("Input to decimal: {0}", inputToDec);
            Console.WriteLine("Input to base {0} is: {1}", baseTo, NumSys.From10ToAny(Convert.ToInt64(inputToDec), baseTo));
        }
    }
}
