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
    }
}