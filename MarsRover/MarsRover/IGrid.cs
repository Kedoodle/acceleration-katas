namespace MarsRover
{
    public interface IGrid
    {
        public int Width { get; } 
        public int Height { get; } 
        ILocation GetLocation(int x, int y);
        ILocation GetAdjacentLocationTo(ILocation location, Direction direction);
    }
}