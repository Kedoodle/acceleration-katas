using System;

namespace blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleGameRenderer = new ConsoleGameRenderer();
            var consoleUserInputGetter = new ConsoleUserInputGetter();
            var game = new Game(consoleGameRenderer, consoleUserInputGetter);
            game.Start();
        }
    }
}