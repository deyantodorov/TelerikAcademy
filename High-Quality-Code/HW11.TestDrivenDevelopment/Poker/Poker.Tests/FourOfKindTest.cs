namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class FourOfKindTest
    {
        private readonly PokerHandsChecker checker = new PokerHandsChecker();

        [Test]
        public void FourOfKindFirstIsValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [Test]
        public void FourOfKindSecondIsValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [Test]
        public void FourOfKindThridIsValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [Test]
        public void FourOfKindFourthIsValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [Test]
        public void FourOfKindFifthIsValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [Test]
        public void FourOfKindNotValidTest()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.IsFalse(this.checker.IsFourOfAKind(hand));
        }
    }
}