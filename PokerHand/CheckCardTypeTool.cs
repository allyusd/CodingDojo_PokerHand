using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class CheckCardTypeTool
    {
        public void Analysis(List<Card> cards)
        {
            if (IsFlush(cards))
            {
                CardType = CardType.Flush;
                return;
            }

            if (IsStraight(cards))
            {
                CardType = CardType.Straight;
                return;
            }

            CardType = CardType.HighCard;
        }

        private static bool IsStraight(List<Card> cards)
        {
            return (cards.GroupBy(c => c.point).Count() == 5)
                   && (cards.Max(c => c.point) - cards.Min(c => c.point) == 4);
        }

        private static bool IsFlush(List<Card> cards)
        {
            return cards.GroupBy(c => c.suit).Count() == 1;
        }

        public CardType CardType { get; private set; }
    }
}