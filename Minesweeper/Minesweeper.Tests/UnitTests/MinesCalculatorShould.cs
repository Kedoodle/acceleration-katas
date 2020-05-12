using Xunit;

namespace Minesweeper.Tests.UnitTests
{
    public class MinesCalculatorShould
    {
        [Theory]
        [InlineData(2, 0, 1)]
        [InlineData(3, 0, 0)]
        [InlineData(4, 0, 0)]
        [InlineData(0, 1, 3)]
        [InlineData(1, 1, 3)]
        [InlineData(2, 1, 2)]
        [InlineData(3, 1, 0)]
        [InlineData(4, 1, 0)]
        [InlineData(0, 2, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 2, 0)]
        [InlineData(4, 2, 0)]
        public void CalculateNumberOfNeighbouringMinesGivenCoordinates(int x, int y, int expectedNeighbouringMines)
        {
            const int width = 5;
            const int height = 3;
            var field = new Field(width, height);
            
            field.SetMine(0, 0); // **100
            field.SetMine(1, 0); // 33200
            field.SetMine(1, 2); // 1*100

            var minesCalculator = new MinesCalculator(field);
            
            Assert.Equal(expectedNeighbouringMines, minesCalculator.CountNeighbouringMines(x, y));
        }
    }
}