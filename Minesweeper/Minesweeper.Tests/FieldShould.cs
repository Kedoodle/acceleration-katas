using System.Linq;
using Xunit;

namespace Minesweeper.Tests
{
    public class FieldShould
    {
        [Fact]
        public void HaveNoMinesByDefault()
        {
            const int width = 5;
            const int height = 3;
            var field = new Field(width, height);
            
            Assert.Equal(width * height, field.Cells.Count);
            Assert.All(field.Cells, cell => Assert.False(cell.IsMine));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        public void SetMineGivenCoordinates(int x, int y)
        {
            const int width = 5;
            const int height = 3;
            var field = new Field(width, height);
            
            field.SetMine(x, y);
            
            Assert.True(field.GetCell(x, y).IsMine);
        }

        [Theory]
        [InlineData(1, 0, 5)] // top
        [InlineData(1, 2, 5)] // bottom
        [InlineData(0, 1, 5)] // left
        [InlineData(2, 1, 5)] // right
        [InlineData(1, 1, 8)] // middle
        [InlineData(0, 0, 3)] // top left
        [InlineData(2, 0, 3)] // top right
        [InlineData(0, 2, 3)] // bottom left
        [InlineData(2, 2, 3)] // bottom right
        public void GetNeighbouringCellsGivenCoordinates(int x, int y, int expectedCellsCount)
        {
            const int width = 3;
            const int height = 3;
            var field = new Field(width, height);

            var neighbouringCells = field.GetNeighbouringCells(x, y);
            
            Assert.Equal(expectedCellsCount, neighbouringCells.Count());
        }
    }
}