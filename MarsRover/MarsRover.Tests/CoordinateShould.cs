using Xunit;

namespace MarsRover.Tests
{
    public class CoordinateShould
    {
        [Fact]
        public void BeEmptyWhenInitialised()
        {
            const int x = 0;
            const int y = 0;
            var coordinate = new Coordinate(x, y);
            
            Assert.True(coordinate.IsEmpty());
        }
    }
}