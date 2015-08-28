namespace Santase.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;

    [TestFixture]
    public class PlayerActionValidatorTest
    {
        private readonly PlayerActionValidater validater = new PlayerActionValidater();

        [Test]
        public void PlayingCardThatsNotInHandShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Diamond, CardType.Jack) };
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Jack), Announce.None);
            var state = new FinalRoundState();
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsFalse(this.validater.IsValid(action, context, cards));
        }

        [Test]
        public void PlayingCardFromHandShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Spade, CardType.King) };
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Spade, CardType.King), Announce.None);
            var state = new FinalRoundState();
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsTrue(this.validater.IsValid(action, context, cards));
        }

        [Test]
        public void PlayerChangesTrumpWithCardShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Nine) };
            var action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsTrue(this.validater.IsValid(action, context, cards));
        }

        [Test]
        public void PlayerChangesTrumpWithQueenShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen) };
            var action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Queen), Announce.None);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsFalse(this.validater.IsValid(action, context, cards));
        }

        [Test]
        public void FourtyAnnounceShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Queen), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            this.validater.IsValid(action, context, cards);

            Assert.AreEqual(Announce.Fourty, announce);
        }

        [Test]
        public void FourtyAnnounceWithoutQueenOrKingShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King), new Card(CardSuit.Heart, CardType.Jack) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.Jack), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            this.validater.IsValid(action, context, cards);

            Assert.AreNotEqual(Announce.Fourty, action.Announce);
        }

        [Test]
        public void FourtyAnnounceWhenPlayerIsNotFirstShouldChangeAnnounceToNone()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King), new Card(CardSuit.Heart, CardType.Jack) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.Jack), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.SecondPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            this.validater.IsValid(action, context, cards);

            Assert.AreEqual(Announce.None, action.Announce);
        }
    }
}
