namespace T01.SquareRoot
{
    using System;

    /// <summary>
    /// 1. Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". 
    ///    In all cases finally print "Good bye". Use try-catch-finally.
    /// </summary>
    public class SquareRoot
    {
        private static void Main()
        {
            RunCalc();
        }

        private static void RunCalc()
        {
            try
            {
                Console.Write("Enter integer number: ");

                string input = Console.ReadLine();
                int value = int.Parse(input);

                Console.WriteLine("{0} square root is {1}", input, CalcSquareRoot(value));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number!");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double CalcSquareRoot(int value)
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("Invalid number!");
            }

            return Math.Sqrt(value);
        }
    }
}
