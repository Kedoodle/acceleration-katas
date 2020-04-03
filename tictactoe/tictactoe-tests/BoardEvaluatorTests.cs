using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class BoardEvaluatorTests
    {
        private const int GridSize = 3;
        
        [Fact]
        public void IsTie_OnFullBoard_WithNoWinCondition()
        {
            var board = new Board(GridSize);
            board.SetCell(0, 0, CellState.O);
            board.SetCell(1, 0, CellState.X);
            board.SetCell(2, 0, CellState.O);
            board.SetCell(0, 1, CellState.O);
            board.SetCell(1, 1, CellState.X);
            board.SetCell(2, 1, CellState.X);
            board.SetCell(0, 2, CellState.X);
            board.SetCell(1, 2, CellState.O);
            board.SetCell(2, 2, CellState.X);
            
            Assert.True(BoardEvaluator.IsTie(board));
        }
        
        [Fact]
        public void HasWinningRow_ForRows_WithWinCondition()
        {
            for (var y = 0; y < GridSize; y++)
            {
                var board = new Board(GridSize);
                FillRow(board, y);
                
                Assert.True(BoardEvaluator.HasWinningRow(board));
            }
        }        
                
        [Fact]
        public void HasWinningColumn_ForColumns_WithWinCondition()
        {
            for (var x = 0; x < GridSize; x++)
            {
                var board = new Board(GridSize);
                FillColumn(board, x);
                
                Assert.True(BoardEvaluator.HasWinningColumn(board));
            }
        }
        
        [Fact]
        public void HasWinningDiagonal_ForDiagonals_WithWinCondition()
        {
            // Top left to bottom right
            {    
                var board = new Board(GridSize);
                for (var xy = 0; xy < GridSize; xy++)
                {
                    board.SetCell(xy, xy, CellState.X);
                }
            
                Assert.True(BoardEvaluator.HasWinningDiagonal(board));
            }
            
            // Bottom left to top right
            {    
                var board = new Board(GridSize);
                for (var xy = 0; xy < GridSize; xy++)
                {
                    board.SetCell(xy, GridSize - 1 - xy, CellState.X);
                }
            
                Assert.True(BoardEvaluator.HasWinningDiagonal(board));
            }
        }

        private static void FillRow(Board board, int y)
        {
            for (var x = 0; x < board.GridSize; x++)
            {
                board.SetCell(x, y, CellState.X);
            }
        }
        
        private static void FillColumn(Board board, int x)
        {
            for (var y = 0; y < board.GridSize; y++)
            {
                board.SetCell(x, y, CellState.X);
            }
        }
    }
}
