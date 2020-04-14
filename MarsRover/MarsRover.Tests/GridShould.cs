using Xunit;

namespace MarsRover.Tests
{
    public class GridShould
    {
        [Fact]
        public void BeEmptyWhenInitialised()
        {
            const int width = 5;
            const int height = 5;
            var grid = new Grid(width, height);

            Assert.True(grid.IsEmpty());
        }
    }
}