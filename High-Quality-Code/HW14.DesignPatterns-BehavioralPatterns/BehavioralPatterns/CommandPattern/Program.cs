using System;

namespace CommandPattern
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine($"X is 20 and Y is 10");
            var calculator = new Calculator(20, 10);

            var cmdAdd = new AddCommand(calculator);
            Console.WriteLine($"Sum is {cmdAdd.Execute()}");

            var cmdSub = new SubstractCommand(calculator);
            Console.WriteLine($"Substract is {cmdSub.Execute()}");

            var cmdMul = new MultiplyCommand(calculator);
            Console.WriteLine($"Multiply is {cmdMul.Execute()}");
        }
    }
}
