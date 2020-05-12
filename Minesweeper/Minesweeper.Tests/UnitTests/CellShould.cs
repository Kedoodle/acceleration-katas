using Xunit;

namespace Minesweeper.Tests.UnitTests
{
    public class CellShould
    {
        [Fact]
        public void BeSafeByDefault()
        {
            const int x = 0;
            const int y = 0;
            var cell = new Cell(x, y);
            Assert.False(cell.IsMine);
        }
    }
}
