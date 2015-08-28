namespace T16.PrintLongSequence
{
    using System;
    
    /// <summary>
    /// 16. Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
    /// </summary>
    public class PrintLongSequence
    {
        private static void Main()
        {
            int start = 2;

            for (int i = 0; i < 1000; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("{0}, ", start);
                }
                else
                {
                    if (i == 999)
                    {
                        Console.Write("-{0}", start);
                    }
                    else
                    {
                        Console.Write("-{0}, ", start);
                    }
                }

                start++;
            }

            Console.WriteLine();
        }
    }
}