using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_IsEmptyOnInitialise()
        {
            const bool expected = true;

            var board = new Board();
            var actual = board.IsEmpty();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_OnSetCell_IsNotEmpty()
        {
            const bool expected = false;
            
            var board = new Board();
            board.SetCell(1, 1, CellState.X);
            var actual = board.IsEmpty();
            
            Assert.Equal(expected, actual);
        }
    }
}