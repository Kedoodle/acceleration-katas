namespace MarsRover
{
    public interface IGrid
    {
        ICoordinate GetCoordinate(int x, int y);
        ICoordinate GetAdjacentCoordinateTo(ICoordinate coordinate, Direction direction);
    }
}