namespace T07.StringEncryption
{
    using System;

    /// <summary>
    /// 7. Write a program that encodes and decodes a string using given encryption key (cipher). 
    ///    The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) 
    ///    operation over the first letter of the string with the first of the key, the second – with the second, etc. 
    ///    When the last key character is reached, the next is the first.
    /// </summary>
    public class StringEncryption
    {
        public static string EncryptDecryptMe(string text)
        {
            char[] cipher = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] myWord = text.ToCharArray();

            int cipherIndex = 0;

            for (int i = 0; i < myWord.Length; i++)
            {
                if (cipherIndex > cipher.Length - 1)
                {
                    cipherIndex = 0;
                }

                myWord[i] ^= cipher[cipherIndex];

                cipherIndex++;
            }

            return new string(myWord);
        }

        private static void Main()
        {
            Console.Write("Enter some for encryption/decrytion: ");
            string input = Console.ReadLine();
            string inputEncrypted = EncryptDecryptMe(input);
            string inputDecrypted = EncryptDecryptMe(inputEncrypted);

            Console.WriteLine("Encrypted: {0}", inputEncrypted);
            Console.WriteLine("Decrypted: {0}", inputDecrypted);
        }
    }
}
