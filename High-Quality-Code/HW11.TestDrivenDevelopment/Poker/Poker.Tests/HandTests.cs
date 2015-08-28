namespace Poker.Tests
{
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void PrintHandsCollection()
        {
            var cards = new List<ICard>();

            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));

            var hand = new Hand(cards);
            var output = new StringBuilder();

            output.AppendLine("Ace Clubs");
            output.AppendLine("Ace Diamonds");
            output.AppendLine("King Hearts");
            output.AppendLine("King Spades");
            output.AppendLine("Seven Diamonds");
            output.AppendLine("Two Clubs");

            Assert.AreEqual(output.ToString().Trim(), hand.ToString(), "Hands ToString doesn't work");
        }
    }
}
