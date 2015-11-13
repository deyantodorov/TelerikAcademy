namespace BinaryPasswords
{
    using System;

    /// <summary>
    /// 01. Двоични пароли
    /// http://bgcoder.com/Contests/Practice/Index/132#0
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var passwordTemplate = Console.ReadLine();
            int unknownDigitsNumber = 0;

            for (int i = 0; i < passwordTemplate.Length; i++)
            {
                if (passwordTemplate[i] == '*')
                {
                    unknownDigitsNumber++;
                }
            }

            long answer = 1;

            for (int i = 1; i <= unknownDigitsNumber; i++)
            {
                answer *= 2;
            }

            Console.WriteLine(answer);
        }
    }
}
