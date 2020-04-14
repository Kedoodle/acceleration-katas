using Xunit;

namespace MarsRover.Tests
{
    public class LocationShould
    {
        [Fact]
        public void BeEmptyWhenInitialised()
        {
            const int x = 0;
            const int y = 0;
            var location = new Location(x, y);
            
            Assert.True(location.IsEmpty());
        }
    }
}