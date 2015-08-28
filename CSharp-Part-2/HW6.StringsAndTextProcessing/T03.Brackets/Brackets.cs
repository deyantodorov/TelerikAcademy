namespace T03.Brackets
{
    using System;

    /// <summary>
    /// 3. Write a program to check if in a given expression the brackets are put correctly.
    ///    Example of correct expression: ((a+b)/5-d).
    ///    Example of incorrect expression: )(a+b)).
    /// </summary>
    public class Brackets
    {
        public static void BracketsValidator()
        {
            Console.Write("Write some expression using brackets: ");
            string input = Console.ReadLine();

            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    index++;
                }
                else if (input[i] == ')')
                {
                    index--;
                }
            }

            if (index == 0)
            {
                Console.WriteLine("Brackets are put correctly.");
            }
            else
            {
                Console.WriteLine("Brackets are put incorrectly.");
            }
        }

        private static void Main()
        {
            BracketsValidator();
        }
    }
}
