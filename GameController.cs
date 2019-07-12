using System;

namespace Mastermind
{
    class GameController
    {
        private IGuessingGame _game;

        public void StartNewMastermindGame()
        {
            _game = new MastermindGame();

            Console.WriteLine("Welcome to Mastermind!  Please enter your guess.");

            while (_game.GameInProgress)
            {
                var userGuess = Console.ReadLine();
                var guessResult = _game.Guess(userGuess);
                Console.WriteLine(guessResult);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}