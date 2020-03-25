namespace tictactoe
{
    public class Game
    {
        private Board _board;
        private const int GridSize = 3;
        
        public void Initialise()
        {
            _board = new Board(GridSize);
        }
        
        public void Start()
        {
            ConsoleHandler.PrintWelcome(_board);
            
            while (!BoardEvaluator.IsFinished(_board))
            {
                break;
            }
        }
    }
}