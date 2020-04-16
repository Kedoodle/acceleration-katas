namespace MarsRover
{
    public interface IGrid
    {
        ICoordinate GetAdjacentCoordinateTo(ICoordinate stubStartingCoordinate, Direction direction);
    }
}