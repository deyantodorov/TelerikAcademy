namespace T04.DeckOfCards
{
    using System;
    using System.Linq;

    /// <summary>
    /// 4. Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). 
    ///    The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
    ///    The card faces should start from 2 to A. 
    ///    Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
    /// </summary>
    public class DeckOfCards
    {
        private static void Main()
        {
            //2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds

            for (int i = 2; i <= 14; i++)
            {
                // It's not necessary to use 2 nested, just do it with one

                var current = string.Empty;

                switch (i)
                {
                    case 11:
                        current = "J";
                        break;
                    case 12:
                        current = "D";
                        break;
                    case 13:
                        current = "K";
                        break;
                    case 14:
                        current = "A";
                        break;
                    default:
                        current = i.ToString();
                        break;
                }

                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", current);
            }
        }
    }
}