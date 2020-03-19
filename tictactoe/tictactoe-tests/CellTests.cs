using System;
using System.Collections.Generic;
using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_EmptyOnInitialise()
        {
            const CellState expected = CellState.Empty;
            
            var cell = new Cell();
            var actual = cell.State;
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_OnPlayerMoveX_ShouldContainX()
        {
            const CellState expected = CellState.X;
            
            var cell = new Cell();
            cell.State = CellState.X;
            var actual = cell.State;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Cell_OnPlayerMoveO_ShouldContainO()
        {
            const CellState expected = CellState.O;
            
            var cell = new Cell();
            cell.State = CellState.O;
            var actual = cell.State;
            
            Assert.Equal(expected, actual);
        }
    }
}