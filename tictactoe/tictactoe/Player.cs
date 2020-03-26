namespace tictactoe
{
    public class Player
    {
        public Player(string name, CellState cellState)
        {
            Name = name;
            CellState = cellState;
        }
        
        public string Name { get; }
        public CellState CellState { get; }

        public void MakeMove(Board board, int x, int y)
        {
            board.SetCell(x, y, CellState);
        }
    }
}