namespace T12.NullValuesArithmetic
{
    using System;

    /// <summary>
    /// 12. Create a program that assigns null values to an integer and to a double variable.
    ///     Try to print these variables at the console. 
    ///     Try to add some number or the null literal to these variables and print the result.
    /// </summary>
    public class NullValuesArithmetic
    {
        private static void Main()
        {
            int? intValue = null;
            double? doubleValue = null;

            ////Print null values
            Console.WriteLine("Value = \"{0}\"", intValue);
            Console.WriteLine("Value = \"{0}\"", doubleValue);

            ////Add some values
            intValue = DateTime.Now.Day;
            doubleValue = DateTime.Now.Year;

            ////Print added values
            Console.WriteLine("Value = \"{0}\"", intValue);
            Console.WriteLine("Value = \"{0}\"", doubleValue);

            ////Add null literal
            intValue = null;
            doubleValue = null;

            Console.WriteLine("{0} {1}", intValue, doubleValue);
        }
    }
}