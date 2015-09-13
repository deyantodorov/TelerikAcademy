namespace SimpleFactory
{
    using System;

    public class Program
    {
        internal static void Main()
        {
            Console.WriteLine("Type 1 to get Health expenses");
            Console.WriteLine("Type 2 to get Travel expenses");
            Console.WriteLine("Type 3 to get Personal expenses");

            var input = Console.ReadLine();
            var checkFactory = new CheckBook();
            var currentExpense = checkFactory.ChooseExpense(int.Parse(input ?? "0"));
            Console.WriteLine($"Expenses are: {currentExpense}");
        }
    }
}
