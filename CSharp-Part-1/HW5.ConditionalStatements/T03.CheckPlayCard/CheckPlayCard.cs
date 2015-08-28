namespace T03.CheckPlayCard
{
    using System;
    using System.Linq;

    /// <summary>
    /// 3. Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. 
    ///    Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. Examples:
    /// </summary>
    public class CheckPlayCard
    {
        private static void Main()
        {
            Console.WriteLine("Enter some card: ");
            bool isValid = IsValidCard(Console.ReadLine());
            Console.WriteLine(isValid ? "yes" : "no");
        }

        private static bool IsValidCard(string input)
        {
            if (input == "2"  || 
                input == "3"  ||
                input == "4"  ||
                input == "5"  ||
                input == "6"  ||
                input == "7"  ||
                input == "8"  ||
                input == "9"  ||
                input == "10" ||
                input == "J"  ||
                input == "Q"  ||
                input == "K"  ||
                input == "A")
            {
                return true;
            }

            return false;
        }
    }
}