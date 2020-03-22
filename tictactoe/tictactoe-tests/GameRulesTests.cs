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
            for (var y = 0; y < GridSize; y++)
            {
                for (var x = 0; x < GridSize; x++)
                {
                    board.SetCell(x, y, CellState.X);
                }
            }
            
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
    }
}