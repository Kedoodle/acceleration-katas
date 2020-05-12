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
    }
}
