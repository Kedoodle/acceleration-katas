using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardTests
    {
        private const int GridSize = 3;
        
        [Fact]
        public void Board_OnInitialise_IsEmpty()
        {
            var board = new Board(GridSize);

            Assert.True(board.IsEmpty());
        }

        [Fact]
        public void Board_OnSetCell_IsNotEmpty()
        {
            var board = new Board(GridSize);
            board.SetCell(1, 1, CellState.X);
            
            Assert.False(board.IsEmpty());
        }

        [Fact]
        public void Board_OnFill_IsFull()
        {
            var board = new Board(GridSize);
            for (var y = 0; y < GridSize; y++)
            {
                for (var x = 0; x < GridSize; x++)
                {
                    board.SetCell(x, y, CellState.X);
                }
            }
            
            Assert.True(board.IsFull());
        }
        
        [Fact]
        public void Board_OnInitialise_IsNotFull()
        {
            var board = new Board(GridSize);
            
            Assert.False(board.IsFull());
        }
    }
}