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

        public void SetMine(int x, int y)
        {
            GetCell(x, y).IsMine = true;
        }
        
        public Cell GetCell(int x, int y)
        {
            return Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public IEnumerable<Cell> GetNeighbouringCells(int x, int y)
        {
            var neighbouringCells = new List<Cell>
            {
                GetCell(x-1, y),
                GetCell(x+1, y),
                GetCell(x, y-1),
                GetCell(x, y+1),
                GetCell(x-1, y-1),
                GetCell(x+1, y-1),
                GetCell(x-1, y+1),
                GetCell(x+1, y+1)
            };
            
            return neighbouringCells.Where(cell => cell != null);
        }
    }
}