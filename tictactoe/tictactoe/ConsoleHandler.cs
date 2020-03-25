using System;

namespace tictactoe
{
    public static class ConsoleHandler
    {
        public static void PrintWelcome(Board board)
        {
            Console.WriteLine(Messages.Welcome);
            Console.WriteLine(Messages.CurrentBoard);
            Console.WriteLine(BoardStringFormatter.GetBoardAsString(board));
        }

        private static class Messages
        {
            internal const string Welcome = "Welcome to Tic Tac Toe!";
            
            internal const string CurrentBoard = "Here's the current board:";
        }
    }
}