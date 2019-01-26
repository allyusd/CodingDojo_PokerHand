using System;
using System.Collections.Generic;

namespace PokerHand
{
    public class CardConverterTool
    {
        private readonly Dictionary<string, CardSuit> _suitLookup = new Dictionary<string, CardSuit>()
        {
            {"S", CardSuit.Spade},
            {"H", CardSuit.Heart},
            {"D", CardSuit.Diamond},
            {"C", CardSuit.Club}
        };

        private readonly Dictionary<string, int> _pointLookup = new Dictionary<string, int>()
        {
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };


        public List<Card> ConvertString(string cardsInput)
        {
            var cards = new List<Card>();

            var strings = cardsInput.Split(',');

            foreach (var str in strings)
            {
                var card = new Card();

                var suit = str.Substring(0, 1);
                card.suit = _suitLookup[suit];

                var point = str.Substring(1, str.Length - 1);

                try
                {
                    card.point = Convert.ToInt32(point);
                }
                catch (FormatException)
                {
                    card.point = _pointLookup[point];
                }

                cards.Add(card);
            }

            return cards;
        }
    }
}