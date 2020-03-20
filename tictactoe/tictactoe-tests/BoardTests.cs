using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_OnInitialise_IsEmpty()
        {
            var board = new Board();

            Assert.True(board.IsEmpty());
        }

        [Fact]
        public void Board_OnSetCell_IsNotEmpty()
        {
            var board = new Board();
            board.SetCell(1, 1, CellState.X);
            
            Assert.False(board.IsEmpty());
        }

        [Fact]
        public void Board_OnFill_IsFull()
        {
            var board = new Board();
            const int GridSize = 3;
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
            var board = new Board();
            
            Assert.False(board.IsFull());
        }
    }
}