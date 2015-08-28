namespace T12.ReadAWord
{
    using System;

    /// <summary>
    /// 12. Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.
    /// </summary>
    public class ReadAWord
    {
        private static void Main()
        {
            // Create array with all letters
            char[] letters = new char[26];

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)(65 + i);
            }

            // Read string
            Console.Write("Enter some word:");
            string input = Console.ReadLine().ToUpper().Trim();

            bool isFound = false;

            char[] inputAsLetters = input.ToCharArray();

            for (int inputIndex = 0; inputIndex < inputAsLetters.Length; inputIndex++)
            {
                for (int lettersIndex = 0; lettersIndex < letters.Length; lettersIndex++)
                {
                    if (inputAsLetters[inputIndex] == letters[lettersIndex])
                    {
                        Console.WriteLine("{0} - index ({1})", letters[lettersIndex], lettersIndex);

                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No match found!");
            }
        }
    }
}
