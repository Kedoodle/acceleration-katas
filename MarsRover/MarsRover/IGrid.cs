namespace MarsRover
{
    public interface IGrid
    {
        public int Width { get; } 
        public int Height { get; } 
        ICoordinate GetCoordinate(int x, int y);
        ICoordinate GetAdjacentCoordinateTo(ICoordinate coordinate, Direction direction);
    }
}