using System.Collections.Generic;

namespace MarsRover
{
    public interface IGrid
    {
        public int Width { get; } 
        public int Height { get; }
        List<ILocation> Locations { get; }
        
        ILocation GetLocation(int x, int y);
        ILocation GetAdjacentLocationTo(ILocation location, Direction direction);
    }
}
