using System;

namespace Poker
{
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count < 5)
            {
                return false;
            }

            if (hand.Cards.Count > 5)
            {
                return false;
            }

            var cards = hand.Cards;

            for (int i = 0; i < cards.Count - 1; i++)
            {
                var currentCard = cards[i];
                var nextCard = cards[i + 1];

                if (currentCard.ToString() == nextCard.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            // Cheers it's summer time
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            this.IsValidHand(hand);

            int match = 1;

            for (int i = 0; i < 2; i++)
            {
                var face = hand.Cards[i].Face;
                match = 1;

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (face == hand.Cards[j].Face)
                    {
                        match++;
                    }
                }

                if (match == 4)
                {
                    return true;
                }
            }

            return match == 4;
        }

        public bool IsFullHouse(IHand hand)
        {
            // Cheers it's summer time
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            this.IsValidHand(hand);

            var suit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (!hand.Cards[i].Suit.Equals(suit))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            // Cheers it's summer time
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            this.IsValidHand(hand);

            int sameCards;

            for (int i = 0; i < 4; i++)
            {
                var current = hand.Cards[i];
                sameCards = 1;
                
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (j != i && current.Face == hand.Cards[j].Face)
                    {
                        sameCards++;
                    }
                }

                if (sameCards == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            this.IsValidHand(hand);
            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ToList();

            var first = false;
            var second = false;

            if (sortedHand[0].Face == sortedHand[1].Face)
            {
                first = true;
            }

            if (sortedHand[2].Face == sortedHand[3].Face)
            {
                second = true;
            }

            if (sortedHand[2].Face == sortedHand[4].Face)
            {
                second = true;
            }

            if (sortedHand[3].Face == sortedHand[4].Face)
            {
                second = true;
            }

            return first && second;
        }

        public bool IsOnePair(IHand hand)
        {
            this.IsValidHand(hand);
            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ToList();

            if (sortedHand[0].Face == sortedHand[1].Face)
            {
                return true;
            }

            if (sortedHand[2].Face == sortedHand[3].Face)
            {
                return true;
            }

            if (sortedHand[2].Face == sortedHand[4].Face)
            {
                return true;
            }

            if (sortedHand[3].Face == sortedHand[4].Face)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            this.IsValidHand(hand);
            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ToList();

            for (int i = 0; i < sortedHand.Count() - 1; i++)
            {
                var current = (int)sortedHand[i].Face;
                var next = (int)sortedHand[i + 1].Face;

                if (current <= next)
                {
                    return false;
                }
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            // Cheers it's summer time
            throw new NotImplementedException();
        }
    }
}
