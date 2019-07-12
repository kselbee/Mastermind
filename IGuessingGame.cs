using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    interface IGuessingGame
    {
        void ResetGame();
        string Guess(string value);
        string Solution { get; }
        int GuessCount { get; }
        bool GameInProgress { get; }
    }
}