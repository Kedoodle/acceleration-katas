namespace tictactoe
{
    public class Cell
    {
        public CellState State { get; set; } = CellState.Empty;
    }
    
    public enum CellState
    {
        Empty,
        X,
        O
    }
}