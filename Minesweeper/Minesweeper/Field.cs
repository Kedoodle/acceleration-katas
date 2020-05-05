using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Field
    {
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            InitialiseCells();
        }

        public int Width { get; }
        public int Height { get; }
        public IList<Cell> Cells { get; } = new List<Cell>();
        
        private void InitialiseCells()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    Cells.Add(new Cell(x, y));
                }
            }
        }
        // get neighbouring cells
        
        public Cell GetCell(int x, int y)
        {
            return Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public void SetMine(int x, int y)
        {
            GetCell(x, y).IsMine = true;
        }

        public IEnumerable<Cell> GetNeighbouringCells(int x, int y)
        {
            var neighbouringCells = new List<Cell>();
            
            if (!IsLeftEdge(x)) neighbouringCells.Add(GetCell(x-1, y));
            if (!IsRightEdge(x)) neighbouringCells.Add(GetCell(x+1, y));
            if (!IsTopEdge(y)) neighbouringCells.Add(GetCell(x, y-1));
            if (!IsBottomEdge(y)) neighbouringCells.Add(GetCell(x, y+1));
            
            if (!IsTopEdge(y) && !IsLeftEdge(x)) neighbouringCells.Add(GetCell(x-1, y-1));
            if (!IsTopEdge(y) && !IsRightEdge(x)) neighbouringCells.Add(GetCell(x+1, y-1));
            if (!IsBottomEdge(y) && !IsLeftEdge(x)) neighbouringCells.Add(GetCell(x-1, y+1));
            if (!IsBottomEdge(y) && !IsRightEdge(x)) neighbouringCells.Add(GetCell(x+1, y+1));
            
            return neighbouringCells;
        }

        private static bool IsLeftEdge(int x)
        {
            return x == 0;
        }

        private bool IsRightEdge(int x)
        {
            return x == Width-1;
        }

        private static bool IsTopEdge(int y)
        {
            return y == 0;
        }

        private bool IsBottomEdge(int y)
        {
            return y == Height-1;
        }
    }
}