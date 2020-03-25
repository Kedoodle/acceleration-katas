using System;

namespace tictactoe
{
    class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            game.Initialise();
            game.Start();
        }
    }
}