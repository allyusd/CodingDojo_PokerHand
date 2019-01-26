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

            CardType = CardType.HighCard;
        }

        private static bool IsFlush(List<Card> cards)
        {
            return cards.GroupBy(c => c.suit).Count() == 1;
        }

        public CardType CardType { get; private set; }
    }
}