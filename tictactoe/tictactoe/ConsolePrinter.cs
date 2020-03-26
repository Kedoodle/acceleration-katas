using System;

namespace tictactoe
{
    public static class ConsolePrinter
    {
        public static void PrintBoard(Board board)
        {
            Console.WriteLine();
            Console.WriteLine(BoardStringFormatter.GetBoardAsString(board));
        }
        
        public static void PrintWelcome()
        {
            Console.WriteLine(Messages.Welcome);
        }

        public static void PrintHeresBoard()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.CurrentBoard);
        }

        public static void PromptPlayerMove(Player player)
        {
            Console.WriteLine();
            Console.Write($"{player.Name} enter a coord x,y to place your {player.CellState} or enter 'q' to give up: ");
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.InvalidInput);
        }

        public static void PrintInvalidCoordinates()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.InvalidCoordinates);
        }

        public static void PrintMoveAccepted()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.MoveAccepted);
        }

        public static void PrintWonGame()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.MoveAcceptedWonGame);
        }
        
        public static void PrintTieGame()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.MoveAcceptedTieGame);
        }

        public static void PrintCellFull()
        {
            Console.WriteLine();
            Console.WriteLine(Messages.CellFull);
        }

        public static void PrintPlayerQuit(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"{player.Name} has quit the game!");
        }

        private static class Messages
        {
            internal const string Welcome = "Welcome to Tic Tac Toe!";
            
            internal const string CurrentBoard = "Here's the current board:";

            internal const string InvalidInput = "Invalid input! Try again...";
            internal const string InvalidCoordinates = "Invalid coordinates! Try again...";
            internal const string MoveAcceptedWonGame = "Move accepted, well done you've won the game!";
            internal const string MoveAcceptedTieGame = "Move accepted, the game is a tie!";
            internal const string MoveAccepted = "Move accepted, here's the current board:";
            internal const string CellFull = "Oh no, a piece is already at this place! Try again...";
            
            
        }
    }
}