using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand
{
    [TestClass]
    public class PokerHandGameTest
    {
        private PokerHandGame _pokerHandGame = new PokerHandGame("Janeway", "Chakotay");

        [TestMethod]
        public void RoyalFlushShouldBeWinStraightFlush()
        {
            var cards1 = "HA,HK,HQ,HJ,H10";
            var cards2 = "S8,S7,S6,S5,S4";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, RoyalFlush", result);
        }

        [TestMethod]
        public void StraightFlushShouldBeWinFourOfKind()
        {
            var cards1 = "S8,S7,S6,S5,S4";
            var cards2 = "D5,S5,H5,C5,H3";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, StraightFlush", result);
        }

        [TestMethod]
        public void FourOfAKindShouldBeWinFullHouse()
        {
            var cards1 = "D5,S5,H5,C5,H3";
            var cards2 = "SK,DK,SK,H5,C5";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, FourOfAKind", result);
        }

        [TestMethod]
        public void FullHouseShouldBeWinFlush()
        {
            var cards1 = "SK,DK,SK,H5,C5";
            var cards2 = "SK,SJ,S9,S7,S3";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, FullHouse", result);
        }

        [TestMethod]
        public void FlushShouldBeWinStraight()
        {
            var cards1 = "SK,SJ,S9,S7,S3";
            var cards2 = "SQ,DJ,C10,S9,H8";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, Flush", result);
        }

        [TestMethod]
        public void StraightShouldBeWinThreeOfAKind()
        {
            var cards1 = "SQ,DJ,C10,S9,H8";
            var cards2 = "SQ,HQ,DQ,S9,S8";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, Straight", result);
        }

        [TestMethod]
        public void ThreeOfAKindShouldBeWinTwoPair()
        {
            var cards1 = "SQ,HQ,DQ,S9,S8";
            var cards2 = "HK,SK,CJ,DJ,D9";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, ThreeOfAKind", result);
        }

        [TestMethod]
        public void TwoPairShouldBeWinOnePair()
        {
            var cards1 = "HK,SK,CJ,DJ,D9";
            var cards2 = "CA,DA,H9,S6,D4";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, TwoPair", result);
        }

        [TestMethod]
        public void OnePairShouldBeWinHighCard()
        {
            var cards1 = "CA,DA,H9,S6,D4";
            var cards2 = "DA,H7,C5,D3,S2";

            string result = _pokerHandGame.GetResult(cards1, cards2);

            Assert.AreEqual("Janeway Win, OnePair", result);
        }
    }
}