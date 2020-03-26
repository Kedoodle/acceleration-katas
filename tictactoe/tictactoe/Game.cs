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
            _currentPlayer = _player1;
        }

        public void Start()
        {
            ConsolePrinter.PrintWelcome();
            ConsolePrinter.PrintHeresBoard();
            ConsolePrinter.PrintBoard(_board);

            while (!BoardEvaluator.IsFinished(_board))
            {
                ConsolePrinter.PromptPlayerMove(_currentPlayer);
                var input = Console.ReadLine();
                if (ConsoleInputParser.TryParseCoordinates(input, out var x, out var y))
                {
                    if (_board.ContainsCoordinates(x, y))
                    {
                        var cell = _board.GetCell(x, y);
                        if (cell.IsEmpty())
                        {
                            _currentPlayer.Move(_board, x, y);
                            if (BoardEvaluator.HasWinCondition(_board))
                            {
                                ConsolePrinter.PrintWonGame();
                            }
                            else if (BoardEvaluator.IsTie(_board))
                            {
                                ConsolePrinter.PrintTieGame();
                            }
                            else
                            {
                                ConsolePrinter.PrintMoveAccepted();
                            }
                            ConsolePrinter.PrintBoard(_board);
                            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
                        }
                        else
                        {
                            ConsolePrinter.PrintCellFull();
                        }
                    }
                    else
                    {
                        ConsolePrinter.PrintInvalidCoordinates();
                    }
                }
                else if (ConsoleInputParser.HasQuit(input))
                {
                    ConsolePrinter.PrintPlayerQuit(_currentPlayer);
                    Environment.Exit(0);
                }
                else
                {
                    ConsolePrinter.PrintInvalidInput();
                }
            }
        }
    }
}
