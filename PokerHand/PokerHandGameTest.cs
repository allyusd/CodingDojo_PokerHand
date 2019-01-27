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
        public void FlushShouldBeWinStraight()
        {
            var cards1 = "SK,SJ,S9,S7,S3";
            var cards2 = "SQ,DJ,C10,S9,H8";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, Flush", result);
        }
    }
}