namespace MarsRover
{
    public interface IGrid
    {
        ICoordinate GetAdjacentCoordinateTo(ICoordinate coordinate, Direction direction);
    }
}