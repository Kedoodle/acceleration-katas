using System;

namespace Minesweeper
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }
        public bool IsMine { get; set; }

        public Cell(int x, int y, bool isMine = false)
        {
            X = x;
            Y = y;
            IsMine = isMine;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var c = (Cell) obj;
            return X == c.X && Y == c.Y && IsMine == c.IsMine;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, IsMine);
        }
    }
}
