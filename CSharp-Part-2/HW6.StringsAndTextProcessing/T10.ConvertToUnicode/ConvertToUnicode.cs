namespace T10.ConvertToUnicode
{
    using System;
    using System.Text;

    /// <summary>
    /// 10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 
    ///     
    ///     Sample input: Hi!
    ///     Expected output: \u0048\u0069\u0021
    /// </summary>
    public class ConvertToUnicode
    {
        public static string Unicoder(string input)
        {
            StringBuilder sb = new StringBuilder(input.Length);

            char[] charArray = input.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                sb.Append(string.Format("\\u{0:X4}", (ushort)charArray[i]));
            }

            return sb.ToString();
        }

        private static void Main()
        {
            Console.Write("Enter some string: ");

            string output = Unicoder(Console.ReadLine());

            Console.WriteLine("Result is: {0}", output);
        }
    }
}
