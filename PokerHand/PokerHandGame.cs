using System.Collections.Generic;

namespace PokerHand
{
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
            List<Card> cards1 = convert.ConvertString(cardsInput1);

            var check = new CheckCardTypeTool();
            check.Analysis(cards1);

            return _player1 + " Win, Flush";
        }
    }
}
