namespace tictactoe
{
    public class Cell
    {
        public CellState State { get; set; } = CellState.Empty;

        public bool IsEmpty()
        {
            return State == CellState.Empty;
        }
    }
    
    public enum CellState
    {
        Empty,
        X,
        O
    }
}