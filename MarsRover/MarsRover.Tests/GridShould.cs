using Xunit;

namespace MarsRover.Tests
{
    public class GridShould
    {
        private readonly Grid _grid;
        public GridShould()
        {
            const int width = 5;
            const int height = 5;
            _grid = new Grid(width, height);
        }
        [Fact]
        public void BeEmptyWhenInitialised()
        {
            Assert.True(_grid.IsEmpty());
        }
    }
}