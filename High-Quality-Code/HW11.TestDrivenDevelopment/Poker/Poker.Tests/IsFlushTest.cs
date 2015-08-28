namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class IsFlushTest
    {
        private PokerHandsChecker checker = new PokerHandsChecker();

        [Test]
        public void HandIsFlushValidTest()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFlush(hand));
        }

        [Test]
        public void HandIsFlushNotValidTest()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            var hand = new Hand(cards);

            Assert.IsFalse(this.checker.IsFlush(hand));
        }
    }
}
