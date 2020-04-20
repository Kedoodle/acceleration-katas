using System.Collections.Generic;

namespace MarsRover
{
    public static class WorldFormatter
    {
        public static IEnumerable<char> FormatRoverStatusSummary(IRover rover)
        {
            var x = rover.Coordinate.X;
            var y = rover.Coordinate.Y;
            var direction = rover.Direction.ToString();
            
            return $"The rover is currently at ({x}, {y}) facing {direction}.";
        }
    }
}