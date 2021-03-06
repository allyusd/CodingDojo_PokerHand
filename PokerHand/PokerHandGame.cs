﻿using System.Collections.Generic;

namespace PokerHand
{
    public class PokerHandGame
    {
        private readonly string _player1;
        private readonly string _player2;

        public PokerHandGame(string player1, string player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public string GetResult(string cardsInput1, string cardsInput2)
        {
            CardConverterTool convert = new CardConverterTool();
            List<Card> cards1 = convert.ConvertString(cardsInput1);
            var check1 = new CheckCardTypeTool();
            check1.Analysis(cards1);

            List<Card> cards2 = convert.ConvertString(cardsInput2);
            var check2 = new CheckCardTypeTool();
            check2.Analysis(cards2);

            string winState;
            string winCardType;
            if (check1.CardType == check2.CardType)
            {
                winState = "Deuce";
                winCardType = check1.CardType.ToString();
            }
            else
            {
                string winPlayer = check1.CardType < check2.CardType ? _player1 : _player2;
                winState = winPlayer + " Win";
                winCardType = check1.CardType < check2.CardType ? check1.CardType.ToString() : check2.CardType.ToString();
            }

            return winState + ", " + winCardType;
        }
    }
}
