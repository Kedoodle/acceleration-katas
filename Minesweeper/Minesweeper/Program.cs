using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new InputReader(Console.In);
            var consoleWriter = new OutputWriter(Console.Out);
            var game = new Game(consoleReader, consoleWriter);
            game.Run();
        }
    }
}