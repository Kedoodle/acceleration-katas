using System.Linq;

namespace tictactoe
{
    public class Board
    {
        private Cell[,] _cellsArray;

        public Board(int gridSize)
        {
            GridSize = gridSize;
            InitialiseBoard();
        }
        
        public int GridSize { get; }

        private void InitialiseBoard()
        {
            _cellsArray = new Cell[GridSize, GridSize];
            for (var i = 0; i < GridSize; i++)
            {
                for (var j = 0; j < GridSize; j++)
                {
                    _cellsArray[i, j] = new Cell();
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return _cellsArray[x, y];
        }

        public void SetCell(int x, int y, CellState cellState)
        {
            _cellsArray[x, y].State = cellState;
        }

        public bool IsEmpty()
        {
            return _cellsArray.OfType<Cell>().All(cell => cell.IsEmpty());
        }

        public bool IsFull()
        {
            return _cellsArray.OfType<Cell>().All(cell => !cell.IsEmpty());
        }

        public bool ContainsCoordinates(int x, int y)
        {
            return x >= 0 && x < GridSize && y >= 0 && y < GridSize;
        }
    }
}
