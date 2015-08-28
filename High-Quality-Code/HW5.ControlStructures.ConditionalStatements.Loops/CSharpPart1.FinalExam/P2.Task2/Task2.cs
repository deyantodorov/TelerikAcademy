namespace P2.Task2
{
    using System;

    public class Task2
    {
        private static int secret;
        private static string text;
        private static double output;

        private static void Main()
        {
            secret = int.Parse(Console.ReadLine());
            text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];

                if (current == '@')
                {
                    return;
                }
                
                if (char.IsLetter(current))
                {
                    output = (int)current * secret + 1000;
                    CalculateAndPrint(i);
                }
                else if (char.IsDigit(current))
                {
                    output = (int)current + secret + 500;
                    CalculateAndPrint(i);
                }
                else
                {
                    output = (int)current - secret;
                    CalculateAndPrint(i);
                }
            }
        }

        private static void CalculateAndPrint(int i)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("{0:F2}", (output / 100));
            }
            else
            {
                Console.WriteLine("{0}", (output * 100));
            }
        }
    }
}