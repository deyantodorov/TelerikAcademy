namespace T13.ReverseSentence
{
    using System;
    using System.Text;

    /// <summary>
    /// 13. Write a program that reverses the words in given sentence. 
    ///     
    ///     Example: "C# is not C++, not PHP and not Delphi!" 
    ///              "Delphi not and PHP, not C++ not is C#!".
    /// </summary>
    public class ReverseSentence
    {
        public static string ReverseIt(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string[] punctuation = text.Split(words, StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[i]);
                sb.Append(punctuation[i]);
            }

            return sb.ToString();
        }

        private static void Main()
        {
            string input = "C# is not C++, not PHP and not Delphi!";
            Console.WriteLine(input);
            Console.WriteLine(ReverseIt(input));
        }
    }
}
