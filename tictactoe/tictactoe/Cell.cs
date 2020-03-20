using System.Drawing;

namespace tictactoe
{
    public class Cell
    {
        public CellState State { get; set; } = CellState.Empty;

        public bool IsEmpty()
        {
            return State == CellState.Empty;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) 
            {
                return false;
            }
            var cell = (Cell) obj; 
            return State == cell.State;
        }
    }
    
    public enum CellState
    {
        Empty,
        X,
        O
    }
}