using System.Linq;

namespace tictactoe
{
    public class Board
    {
        private Cell[,] CellsArray;
        private const int GridSize = 3;

        public Board()
        {
            InitialiseEmptyCellsArray();
        }

        private void InitialiseEmptyCellsArray()
        {
            CellsArray = new Cell[GridSize, GridSize];
            for (var i = 0; i < GridSize; i++)
            {
                for (var j = 0; j < GridSize; j++)
                {
                    CellsArray[i, j] = new Cell();
                }
            }
        }

        public bool IsEmpty()
        {
            return CellsArray.Cast<Cell>().All(cell => cell.IsEmpty());
        }

        public void SetCell(int x, int y, CellState cellState)
        {
            CellsArray[x, y].State = cellState;
        }
    }
}