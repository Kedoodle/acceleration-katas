using Xunit;

namespace Minesweeper.Tests
{
    public class MinesCalculatorShould
    {
        [Fact]
        public void CalculateNumberOfNeighbouringMinesGivenCoordinates()
        {
            const int width = 5;
            const int height = 3;
            var field = new Field(width, height);
            
            field.SetMine(0, 0); // **100
            field.SetMine(1, 0); // 33200
            field.SetMine(1, 2); // 1*100

            var minesCalculator = new MinesCalculator(field);
            
            Assert.Equal(1, minesCalculator.GetMines(2, 0));
            Assert.Equal(0, minesCalculator.GetMines(3, 0));
            Assert.Equal(0, minesCalculator.GetMines(4, 0));
            Assert.Equal(3, minesCalculator.GetMines(0, 1));
            Assert.Equal(3, minesCalculator.GetMines(1, 1));
            Assert.Equal(2, minesCalculator.GetMines(2, 1));
            Assert.Equal(0, minesCalculator.GetMines(3, 1));
            Assert.Equal(0, minesCalculator.GetMines(4, 1));
            Assert.Equal(1, minesCalculator.GetMines(0, 2));
            Assert.Equal(1, minesCalculator.GetMines(2, 2));
            Assert.Equal(0, minesCalculator.GetMines(3, 2));
            Assert.Equal(0, minesCalculator.GetMines(4, 2));
        }
    }
}