using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class CheckCardTypeTool
    {
        public void Analysis(List<Card> cards)
        {
            if (CardsHasOncePointCard(cards, 10)
                && CardsHasOncePointCard(cards, 11)
                && CardsHasOncePointCard(cards, 12)
                && CardsHasOncePointCard(cards, 13)
                && CardsHasOncePointCard(cards, 14)
                && IsFlush(cards))
            {
                CardType = CardType.RoyalFlush;
                return;
            }

            if (IsStraight(cards) && IsFlush(cards))
            {
                CardType = CardType.StraightFlush;
                return;
            }

            if (IsFlush(cards))
            {
                CardType = CardType.Flush;
                return;
            }

            if (IsStraight(cards) || IsSpecialStraight(cards))
            {
                CardType = CardType.Straight;
                return;
            }

            CardType = CardType.HighCard;
        }

        private static bool IsSpecialStraight(List<Card> cards)
        {
            return CardsHasOncePointCard(cards, 14)
                && CardsHasOncePointCard(cards, 2)
                && CardsHasOncePointCard(cards, 3)
                && CardsHasOncePointCard(cards, 4)
                && CardsHasOncePointCard(cards, 5);
        }

        private static bool CardsHasOncePointCard(List<Card> cards, int point)
        {
            return cards.Count(c => c.point == point) == 1;
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