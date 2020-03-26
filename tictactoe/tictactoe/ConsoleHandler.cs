using System;

namespace tictactoe
{
    public static class ConsoleHandler
    {
        public static void PrintWelcome(Board board)
        {
            Console.WriteLine(Messages.Welcome);
            Console.WriteLine();
            Console.WriteLine(Messages.CurrentBoard);
            Console.WriteLine(BoardStringFormatter.GetBoardAsString(board));
            Console.WriteLine();
        }

        private static class Messages
        {
            internal const string Welcome = "Welcome to Tic Tac Toe!";
            
            internal const string CurrentBoard = "Here's the current board:";
        }

        public static void PrintPromptPlayerMove(Player player)
        {
            Console.Write($"{player.Name} enter a coord x,y to place your {player.CellState} or enter 'q' to give up: ");
        }
    }
}