using System;
using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardStringFormatterTests
    {
        private const int GridSize = 3;
        
        [Fact]
        public void FormatBoardToString_ReturnsValidString()
        {

            var expected = "OXO" + Environment.NewLine
                                 + "..." + Environment.NewLine
                                 + "XOX";
                
            var board = new Board(GridSize);
            board.SetCell(0, 0, CellState.O);
            board.SetCell(1, 0, CellState.X);
            board.SetCell(2, 0, CellState.O);
            board.SetCell(0, 2, CellState.X);
            board.SetCell(1, 2, CellState.O);
            board.SetCell(2, 2, CellState.X);
            var actual = BoardStringFormatter.GetBoardAsString(board);
            
            Assert.Equal(expected, actual);
        }
    }
}