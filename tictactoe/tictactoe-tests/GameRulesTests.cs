using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class GameRulesTests
    {
        private const int GridSize = 3;
        
        [Fact]
        public void IsTie_OnFullBoard_ReturnsTrue()
        {
            var board = new Board();
            board.SetCell(0, 0, CellState.X);
            board.SetCell(1, 0, CellState.O);
            board.SetCell(2, 0, CellState.X);
            board.SetCell(0, 1, CellState.O);
            board.SetCell(1, 1, CellState.X);
            board.SetCell(2, 1, CellState.X);
            board.SetCell(0, 2, CellState.X);
            board.SetCell(1, 2, CellState.O);
            board.SetCell(2, 2, CellState.X);
            
            Assert.True(GameRules.IsTie(board));
        }

        [Fact]
        public void HasWinningRow_TopRowSame_ReturnsTrue()
        {
            var board = new Board();
            const int y = 0;
            for (var x = 0; x < GridSize; x++)
            {
                board.SetCell(x, y, CellState.X);
            }
            
            Assert.True(GameRules.HasWinningRow(board));
        }
        
        [Fact]
        public void HasWinningRow_BottomRowSame_ReturnsTrue()
        {
            var board = new Board();
            const int y = GridSize - 1;
            for (var x = 0; x < GridSize; x++)
            {
                board.SetCell(x, y, CellState.X);
            }
            
            Assert.True(GameRules.HasWinningRow(board));
        }
        
        [Fact]
        public void HasWinningColumn_LeftMostColumnSame_ReturnsTrue()
        {
            var board = new Board();
            const int x = 0;
            for (var y = 0; y < GridSize; y++)
            {
                board.SetCell(x, y, CellState.X);
            }
            
            Assert.True(GameRules.HasWinningColumn(board));
        }    
        
        [Fact]
        public void HasWinningColumn_RightMostColumnSame_ReturnsTrue()
        {
            var board = new Board();
            const int x = GridSize - 1;
            for (var y = 0; y < GridSize; y++)
            {
                board.SetCell(x, y, CellState.X);
            }
            
            Assert.True(GameRules.HasWinningColumn(board));
        }
    }
}