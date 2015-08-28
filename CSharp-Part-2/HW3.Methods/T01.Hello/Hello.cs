namespace T01.Hello
{
    using System;

    /// <summary>
    /// 1. Write a method that asks the user for his name and prints “Hello, name” (for example, “Hello, Peter!”). Write a program to test this method.
    /// </summary>
    public class Hello
    {
        private static void Main()
        {
            SayHello();
        }

        private static void SayHello()
        {
            Console.Write("Type your name: ");
            string input = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", input);
        }
    }
}
