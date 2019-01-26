using System;
using System.Collections.Generic;

namespace PokerHand
{
    public class CardConverterTool
    {
        private readonly Dictionary<string, CardSuit> _suitLookup = new Dictionary<string, CardSuit>()
        {
            {"H", CardSuit.Heart}
        };

        public List<Card> ConvertStringToCards(string cardsInput)
        {
            var cards = new List<Card>();

            var strings = cardsInput.Split(',');

            foreach (var str in strings)
            {
                var card = new Card();

                var suit = str.Substring(0, 1);

                card.suit = _suitLookup[suit];

                var point = str.Substring(1, str.Length - 1);

                card.point = Convert.ToInt32(point);

                cards.Add(card);
            }

            return cards;
        }
    }
}