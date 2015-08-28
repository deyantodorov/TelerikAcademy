namespace T14.MyDictionary
{
    using System;
    using System.Collections;

    /// <summary>
    /// 14. A dictionary is stored as a sequence of text lines containing words and their explanations. 
    ///     Write a program that enters a word and translates it by using the dictionary. 
    ///     
    ///     Sample dictionary:
    ///     .NET – platform for applications from Microsoft
    ///     CLR – managed execution environment for .NET
    ///     namespace – hierarchical organization of classes
    /// </summary>
    public class MyDictionary
    {
        private static void Main()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(".NET", "platform for applications from Microsoft");
            hashtable.Add("CLR", "managed execution environment for .NET");
            hashtable.Add("namespace", "hierarchical organization of classes");

            Console.Write("Enter some word: ");
            string input = Console.ReadLine();
            string result = (string)hashtable[input];

            while (true)
            {
                if (result == null)
                {
                    Console.WriteLine("No such word in my dictionary.");
                    input = Console.ReadLine();
                    result = (string)hashtable[input];
                }
                else
                {
                    Console.WriteLine("{0} - {1}", input, result);
                    break;
                }
            }
        }
    }
}
