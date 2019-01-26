using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand
{
    [TestClass]
    public class CardConverterToolTest
    {
        private readonly CardConverterTool _cardConverterTool = new CardConverterTool();

        [TestMethod]
        public void NormalCase()
        {
            var cards = _cardConverterTool.ConvertString("H2,H3,H4,H5,H6");

            Assert.AreEqual(5, cards.Count);
            CardShouldBe(CardSuit.Heart, 2, cards[0]);
            CardShouldBe(CardSuit.Heart, 3, cards[1]);
            CardShouldBe(CardSuit.Heart, 4, cards[2]);
            CardShouldBe(CardSuit.Heart, 5, cards[3]);
            CardShouldBe(CardSuit.Heart, 6, cards[4]);
        }

        [TestMethod]
        public void AllSuit()
        {
            var cards = _cardConverterTool.ConvertString("S2,H3,D4,C5,S6");

            Assert.AreEqual(5, cards.Count);
            CardShouldBe(CardSuit.Spade, 2, cards[0]);
            CardShouldBe(CardSuit.Heart, 3, cards[1]);
            CardShouldBe(CardSuit.Diamond, 4, cards[2]);
            CardShouldBe(CardSuit.Club, 5, cards[3]);
            CardShouldBe(CardSuit.Spade, 6, cards[4]);
        }

        [TestMethod]
        public void SpecialPoint()
        {
            var cards = _cardConverterTool.ConvertString("H10,HJ,HQ,HK,HA");

            Assert.AreEqual(5, cards.Count);
            CardShouldBe(CardSuit.Heart, 10, cards[0]);
            CardShouldBe(CardSuit.Heart, 11, cards[1]);
            CardShouldBe(CardSuit.Heart, 12, cards[2]);
            CardShouldBe(CardSuit.Heart, 13, cards[3]);
            CardShouldBe(CardSuit.Heart, 14, cards[4]);
        }

        private static void CardShouldBe(CardSuit suit, int point, Card card)
        {
            Assert.AreEqual(suit, card.suit);
            Assert.AreEqual(point, card.point);
        }
    }
}