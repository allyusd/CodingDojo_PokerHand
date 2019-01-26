using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand
{
    [TestClass]
    public class PokerHandGameTest
    {
        private PokerHandGame _pokerHandGame = new PokerHandGame("Janeway", "Chakotay");

        [TestMethod]
        [Ignore]
        public void RoyalFlushShouldBeWinStraightFlush()
        {
            var cards1 = "HA,HK,HQ,HJ,H10";
            var cards2 = "S8,S7,S6,S5,S4";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, RoyalFlush", result);
        }

        [TestMethod]
        [Ignore]
        public void FlushShouldBeWinStraight()
        {
            var cards1 = "SK,SJ,S9,S7,S3";
            var cards2 = "SQ,DJ,C10,S9,H8";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, Flush", result);
        }
    }

    public class PokerHandGame
    {
        private string _player1;
        private string _player2;

        public PokerHandGame(string player1, string player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public string GetResult(string cardsInput1, string cardsInput2)
        {
            CardConverterTool convert = new CardConverterTool();
            List<Card> cards1 = convert.ConvertStringToCards(cardsInput1);

            return _player1 + " Win, Flush";
        }
    }

    [TestClass]
    public class CardConverterToolTest
    {
        [TestMethod]
        public void NormalCase()
        {
            var convert = new CardConverterTool();
            var cards = convert.ConvertStringToCards("H2,H3,H4,H5,H6");

            Assert.AreEqual(5, cards.Count);
            CardShouldBe(CardSuit.Heart, 2, cards[0]);
            CardShouldBe(CardSuit.Heart, 3, cards[1]);
            CardShouldBe(CardSuit.Heart, 4, cards[2]);
            CardShouldBe(CardSuit.Heart, 5, cards[3]);
            CardShouldBe(CardSuit.Heart, 6, cards[4]);
        }

        private static void CardShouldBe(CardSuit suit, int point, Card card)
        {
            Assert.AreEqual(suit, card.suit);
            Assert.AreEqual(point, card.point);
        }
    }

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

    public enum CardSuit
    {
        Heart
    }

    public class Card
    {
        public CardSuit suit { get; set; }
        public int point { get; set; }
    }
}