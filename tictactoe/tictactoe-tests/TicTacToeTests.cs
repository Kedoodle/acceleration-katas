using System;
using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class TicTacToeTests
    {
        [Fact]
        public void Cell_OnInstantiate_HasStateEmpty()
        {
            const CellState expected = CellState.Empty;
            var cell = new Cell();
            var actual = cell.State;
            Assert.Equal(expected, actual);
        }
    }
}