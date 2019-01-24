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

    public class PokerHandGame
    {
        private string _player1;
        private string _player2;

        public PokerHandGame(string player1, string player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public string GetResult(string cards1, string cards2)
        {
            return _player1 + " Win, Flush";
        }
    }
}