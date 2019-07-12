namespace Mastermind
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            var game = new GameController();
            game.StartNewMastermindGame();
        }
    }
}