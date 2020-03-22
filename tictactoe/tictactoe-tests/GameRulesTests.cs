using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class GameRulesTests
    {
        [Fact]
        public void IsTie_OnFullBoard_ReturnsTrue()
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
            
            Assert.True(GameRules.IsTie(board));
        }
    }
}