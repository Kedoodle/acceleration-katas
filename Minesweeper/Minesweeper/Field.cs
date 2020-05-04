using System.Collections.Generic;

namespace Minesweeper
{
    public class Field
    {
        public IList<Cell> Cells { get; } = new List<Cell>();
        private int _height = 0;
        
        public void AddRow(string rowString)
        {
            var y = _height;
            for (var x = 0; x < rowString.Length; x++)
            {
                var isMine = rowString[x] == '*';
                Cells.Add(new Cell(x, y, isMine));
            }
            _height++;
        }
    }
}