namespace T12.StackImplementation
{
    using System;

    public class Program
    {
        private static void Main()
        {
            var stackCustom = new StackCustom<string>();

            stackCustom.Push("Ivan");
            stackCustom.Push("Pesho");
            stackCustom.Push("Dimitar");
            stackCustom.Push("Maria");

            Console.WriteLine("Top = {0}", stackCustom.Peak());

            while (stackCustom.Count > 0)
            {
                Console.WriteLine(stackCustom.Pop());
            }
        }
    }
}
