using System;
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
            var actual = board.ToString();
            
            Assert.Equal(expected, actual);
        }
    }
}