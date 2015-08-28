namespace Santase.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void DeckCreationTest()
        {
            var deck = new Deck();

            var card = deck.GetNextCard();

            Assert.AreNotEqual("", card.Suit, "Card suit problem on deck creation");
            Assert.AreNotEqual("", card.Type, "Card type problem on deck creation");
        }

        [TestCase(CardSuit.Club, CardType.Ace)]
        [TestCase(CardSuit.Spade, CardType.Jack)]
        [TestCase(CardSuit.Diamond, CardType.King)]
        [TestCase(CardSuit.Club, CardType.Nine)]
        [TestCase(CardSuit.Heart, CardType.Queen)]
        public void ChangeTrumpCardTest(CardSuit suit, CardType type)
        {
            var newCard = new Card(suit, type);
            var deck = new Deck();

            deck.ChangeTrumpCard(newCard);

            Assert.AreNotEqual(0, deck.CardsLeft, "Change card doesn't work");
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(24)]
        public void DeckToReturnDifferentCards(int count)
        {
            var deck = new Deck();
            var cards = new List<Card>();

            for (int card = 0; card < 24; card++)
            {
                cards.Add(deck.GetNextCard());
            }

            foreach (Card card in cards)
            {
                Assert.That(card, Is.InstanceOf<Card>(), "Invalid Card type");
            }
        }
    }
}
