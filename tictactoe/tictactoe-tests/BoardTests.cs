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
    }
}