using System.Collections.Generic;
using Xunit;

namespace Minesweeper.Tests
{
    public class FieldShould
    {
        [Fact]
        public void AddCellsByRow()
        {
            var expectedCells = new List<Cell>
            {
                new Cell(0, 0, true),
                new Cell(1, 0),
                new Cell(2, 0),
                new Cell(3, 0),
                
                new Cell(0, 1),
                new Cell(1, 1),
                new Cell(2, 1),
                new Cell(3, 1),
                
                new Cell(0, 2),
                new Cell(1, 2, true),
                new Cell(2, 2),
                new Cell(3, 2),
                
                new Cell(0, 3),
                new Cell(1, 3),
                new Cell(2, 3),
                new Cell(3, 3)
            };
            
            var field = new Field();
            field.AddRow("*...");
            field.AddRow("....");
            field.AddRow(".*..");
            field.AddRow("....");
            
            Assert.Equal(expectedCells, field.Cells);
        }
    }
}