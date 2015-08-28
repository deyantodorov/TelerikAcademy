namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsValidTest
    {
        private readonly IPokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

        [Test]
        public void HandWithoutCardsTest()
        {
            var hand = new Hand(new List<ICard>());
            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithFiveDifferentCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsTrue(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithSixDifferentCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithTwoEqualCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithFiveEqualCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithTwoEqualPairOfCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithTwoEqualOfFourCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }

        [Test]
        public void HandWithTwoEqualOfSixCardsTest()
        {
            var hand = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsFalse(this.pokerHandsChecker.IsValidHand(hand));
        }
    }
}
