using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_IsEmptyOnInitialise()
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
    }
}