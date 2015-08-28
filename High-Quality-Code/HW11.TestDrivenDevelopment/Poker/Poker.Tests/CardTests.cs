namespace Poker.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [TestCase(CardFace.Ace, CardSuit.Clubs)]
        [TestCase(CardFace.Ace, CardSuit.Diamonds)]
        [TestCase(CardFace.Ace, CardSuit.Hearts)]
        [TestCase(CardFace.Ace, CardSuit.Spades)]
        [TestCase(CardFace.Two, CardSuit.Clubs)]
        public void CardCreationTest(CardFace face, CardSuit suit)
        {
            var card = new Card(face, suit);

            Assert.IsInstanceOfType(typeof(ICard), card, "Could not create card");
        }

        [TestCase(CardFace.Ace, CardSuit.Clubs, "Ace Clubs")]
        [TestCase(CardFace.Ace, CardSuit.Diamonds, "Ace Diamonds")]
        [TestCase(CardFace.King, CardSuit.Hearts, "King Hearts")]
        [TestCase(CardFace.King, CardSuit.Spades, "King Spades")]
        [TestCase(CardFace.Seven, CardSuit.Diamonds, "Seven Diamonds")]
        [TestCase(CardFace.Two, CardSuit.Clubs, "Two Clubs")]
        public void CardToStringIsCorrect(CardFace face, CardSuit suit, string result)
        {
            var card = new Card(face, suit);
            Assert.AreEqual(result, card.ToString(), "Card ToString is incorrect");
        }
    }
}
