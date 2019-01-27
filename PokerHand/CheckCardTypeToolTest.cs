using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand
{
    [TestClass]
    public class CheckCardTypeToolTest
    {
        private readonly CheckCardTypeTool _checkTool = new CheckCardTypeTool();
        private readonly CardConverterTool _converter = new CardConverterTool();

        [TestMethod]
        public void CheckFlush()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,S4,S6,S8,S10"));
            Assert.AreEqual(CardType.Flush, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckStraight()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D4,C5,S6"));
            Assert.AreEqual(CardType.Straight, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckSpecialStraight()
        {
            _checkTool.Analysis(_converter.ConvertString("SA,H2,D3,C4,S5"));
            Assert.AreEqual(CardType.Straight, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckFourOfKind()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D2,C2,S2"));
            Assert.AreEqual(CardType.FourOfAKind, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckFullHouse()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D3,C2,S2"));
            Assert.AreEqual(CardType.FullHouse, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckThreeOfKind()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D4,C2,S2"));
            Assert.AreEqual(CardType.ThreeOfAKind, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckTwoPair()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D3,C5,S2"));
            Assert.AreEqual(CardType.TwoPair, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckOnePair()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D4,C5,S2"));
            Assert.AreEqual(CardType.OnePair, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckHighCard()
        {
            _checkTool.Analysis(_converter.ConvertString("S2,H3,D4,C5,S7"));
            Assert.AreEqual(CardType.HighCard, _checkTool.CardType);
        }

        [TestMethod]
        public void CheckStraightFlushMaxPoints()
        {
            _checkTool.Analysis(_converter.ConvertString("S5,S4,S6,S8,S7"));
            Assert.AreEqual(CardType.StraightFlush, _checkTool.CardType);
            Assert.AreEqual(5, _checkTool.MaxPoints.Count);
            Assert.AreEqual(8, _checkTool.MaxPoints[0]);
            Assert.AreEqual(7, _checkTool.MaxPoints[1]);
            Assert.AreEqual(6, _checkTool.MaxPoints[2]);
            Assert.AreEqual(5, _checkTool.MaxPoints[3]);
            Assert.AreEqual(4, _checkTool.MaxPoints[4]);
        }
    }
}