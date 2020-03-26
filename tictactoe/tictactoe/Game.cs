namespace tictactoe
{
    public class Game
    {
        private Board _board;
        private Player _player1;
        private Player _player2;
        
        private const int GridSize = 3;
        
        public void Initialise()
        {
            _board = new Board(GridSize);
            _player1 = new Player("1", CellState.X);
            _player2 = new Player("2", CellState.O);
        }
        
        public void Start()
        {
            ConsoleHandler.PrintWelcome(_board);
            
            while (!BoardEvaluator.IsFinished(_board))
            {
                ConsoleHandler.PrintPromptPlayerMove(_player1);
                
                break;
            }
        }
    }

    public struct Player
    {
        public string Name { get; }
        public CellState CellPiece { get; }

        public Player(string name, CellState cellPiece)
        {
            Name = name;
            CellPiece = cellPiece;
        }
    }
}