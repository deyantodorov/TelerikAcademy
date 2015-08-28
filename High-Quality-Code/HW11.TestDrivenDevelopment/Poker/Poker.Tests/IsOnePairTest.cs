namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class IsOnePairTest
    {
        private readonly PokerHandsChecker checker = new PokerHandsChecker();

        [TestCase(CardFace.Ace, CardSuit.Diamonds, CardFace.Ace, CardSuit.Diamonds, CardFace.Nine, CardSuit.Spades, CardFace.Five, CardSuit.Clubs, CardFace.Four, CardSuit.Clubs)]
        [TestCase(CardFace.King, CardSuit.Diamonds, CardFace.Queen, CardSuit.Diamonds, CardFace.Jack, CardSuit.Spades, CardFace.Jack, CardSuit.Clubs, CardFace.Seven, CardSuit.Clubs)]
        [TestCase(CardFace.Ace, CardSuit.Diamonds, CardFace.Queen, CardSuit.Diamonds, CardFace.Seven, CardSuit.Spades, CardFace.Five, CardSuit.Clubs, CardFace.Five, CardSuit.Clubs)]
        public void IsOnePairTestValid(CardFace face1, CardSuit suit1, CardFace face2, CardSuit suit2, CardFace face3, CardSuit suit3, CardFace face4, CardSuit suit4, CardFace face5, CardSuit suit5)
        {
            // Didn't found better way to implement many cards with NUnit
            var cards = new List<ICard>()
            {
                new Card(face1, suit1),
                new Card(face2, suit2),
                new Card(face3, suit3),
                new Card(face4, suit4),
                new Card(face5, suit5),
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsOnePair(hand));
        }
    }
}
