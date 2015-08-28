namespace T03.PrintNumbers
{
    using System;

    /// <summary>
    /// 3. Write a program to print the numbers 1, 101 and 1001, each at a separate line..
    /// </summary>
    public class PrintNumbers
    {
        private static void Main()
        {
            // Here you can see algorithm for 1 to 100001, be carefull because you can fill the int.
            for (int i = 1; i <= 5; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(1 + (int)Math.Pow(10, i));
                }
            }
        }
    }
}
