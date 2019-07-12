using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class MastermindGame : IGuessingGame
    {
        public MastermindGame()
        {
            ResetGame();
        }

        private const int GAMESIZE = 4;
        private const int MAXGUESSES = 10;
        private const int MINVALUE = 1;
        private const int MAXVALUE = 6;

        private static readonly Random _random = new Random();
        private int[] _solution = new int[GAMESIZE];

        public bool GameInProgress { get; private set; } = true;
        public int GuessCount { get; private set; } = 0;
        public string Solution => string.Join(string.Empty, _solution);


        public void ResetGame()
        {
            _solution = _solution.Select(e => _random.Next(MINVALUE, MAXVALUE)).ToArray();
            GameInProgress = true;
            GuessCount = 0;
        }

        public string Guess(string guess)
        {
            // validate guess
            var guessValues = guess.ToCharArray();
            IEnumerable<int> validRange = Enumerable.Range(MINVALUE, MAXVALUE + 1);
            var validValues = string.Join(string.Empty, validRange);
            if (guessValues.Length != GAMESIZE || !guessValues.All(v => validValues.Contains(v)))
            {
                return $"Invalid guess.  You should guess {GAMESIZE} numbers from {MINVALUE} to {MAXVALUE}.  Please try again.";
            }

            int[] parsedGuessValues = Array.ConvertAll(guessValues, v => (int)Char.GetNumericValue(v));
            GuessCount++;

            // check guess against solution
            string hint = string.Empty;
            var correctSolution = true;
            for (int i = 0; i < GAMESIZE; i++)
            {
                if (parsedGuessValues[i] == _solution[i])
                {   // correct guess in correct position
                    hint += '+';
                }
                else if (_solution.Any(e => e == parsedGuessValues[i]))
                {   // correct guess in wrong position
                    hint += '-';
                    correctSolution = false;
                }
                else
                {   // incorrect guess
                    correctSolution = false;
                }
            }

            if (correctSolution)
            {
                GameInProgress = false;
                return $"You guessed the correct solution in {GuessCount} guesses!";
            }
            else if (GuessCount >= MAXGUESSES)
            {
                GameInProgress = false;
                return $"You are out of guesses.  The correct answer is {Solution}.";
            }
            else
            {
                return hint;
            }
        }
    }
}
