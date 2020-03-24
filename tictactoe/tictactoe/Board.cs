using System.Linq;

namespace tictactoe
{
    public class Board
    {
        private Cell[,] CellsArray;

        public Board(int gridSize)
        {
            GridSize = gridSize;
            InitialiseBoard();
        }
        
        public int GridSize { get; }

        private void InitialiseBoard()
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

        public bool IsFull()
        {
            return CellsArray.Cast<Cell>().All(cell => !cell.IsEmpty());
        }

        public Cell GetCell(int x, int y)
        {
            return CellsArray[x, y];
        }
    }
}