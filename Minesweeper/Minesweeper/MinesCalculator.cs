using System.Linq;

namespace Minesweeper
{
    public class MinesCalculator
    {
        private readonly Field _field;

        public MinesCalculator(Field field)
        {
            _field = field;
        }

        public int CountNeighbouringMines(int x, int y)
        {
            return _field.GetNeighbouringCells(x, y).Count(cell => cell.IsMine);
        }
    }
}