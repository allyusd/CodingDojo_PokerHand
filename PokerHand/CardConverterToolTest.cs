using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand
{
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
}