namespace T14.TableAscii
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 14. Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
    /// </summary>
    public class TableAscii
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            ushort symbol = 0;

            while (symbol <= 255)
            {
                Console.WriteLine("{0} = {1}", symbol, (char)symbol);
                symbol++;
            }
        }
    }
}