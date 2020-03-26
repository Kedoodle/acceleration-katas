using System;

namespace tictactoe
{
    public class Game
    {
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;
        
        private const int GridSize = 3;
        
        public void Initialise()
        {
            _board = new Board(GridSize);
            _player1 = new Player("Player 1", CellState.X);
            _player2 = new Player("Player 2", CellState.O);
        }
        
        public void Start()
        {
            ConsolePrinter.PrintWelcome(_board);
            
            while (!BoardEvaluator.IsFinished(_board))
            {
                ConsolePrinter.PrintPromptPlayerMove(_player1);
                var input = Console.ReadLine();
                if (ConsoleInputParser.HasQuit(input))
                {
                    
                }
                break;
            }
        }
    }
}