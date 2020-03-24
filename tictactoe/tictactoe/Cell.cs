
namespace tictactoe
{
    public class Cell
    {
        public CellState State { get; set; } = CellState.Empty;

        public bool IsEmpty()
        {
            return State == CellState.Empty;
        }

        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cell);
        }

        public bool Equals(Cell cell)
        {
            if (ReferenceEquals(cell, null))
            {
                return false;
            }
            if (ReferenceEquals(this, cell))
            {
                return true;
            }
            if (this.GetType() != cell.GetType())
            {
                return false;
            }
            
            return this.State == cell.State;
        }

        public static bool operator ==(Cell lhs, Cell rhs)
        {
            return lhs?.Equals(rhs) ?? ReferenceEquals(rhs, null);
        }

        public static bool operator !=(Cell lhs, Cell rhs)
        {
            return !(lhs == rhs);
        }
    }
    
    public enum CellState
    {
        Empty,
        X,
        O
    }
}
