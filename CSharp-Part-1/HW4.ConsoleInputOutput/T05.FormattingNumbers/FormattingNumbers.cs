namespace T05.FormattingNumbers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 5. Write a program that reads 3 numbers:
    //     integer a (0 <= a <= 500)
    //     floating-point b
    //     floating-point c
    //     The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
    //     The number a should be printed in hexadecimal, left aligned
    //     Then the number a should be printed in binary form, padded with zeroes
    //     The number b should be printed with 2 digits after the decimal point, right aligned
    //     The number c should be printed with 3 digits after the decimal point, left aligned.
    /// </summary>
    public class FormattingNumbers
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;

            Console.Write("Enter integer a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter float b: ");
            float b = float.Parse(Console.ReadLine().Replace(',', '.'));

            Console.Write("Enter float c: ");
            float c = float.Parse(Console.ReadLine().Replace(',', '.'));

            Console.Write("{0:X}", a.ToString().PadRight(10));
            Console.Write("{0, 10}", Convert.ToString(a, 2));
            Console.Write("{0, 10:F2}", b);
            Console.Write("{0, 10:F4}", c.ToString().PadLeft(10));
            Console.WriteLine();
        }
    }
}