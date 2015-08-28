namespace Poker
{
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (ICard card in this.Cards)
            {
                output.AppendLine(card.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
