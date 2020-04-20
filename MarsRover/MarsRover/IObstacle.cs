namespace MarsRover
{
    public interface IObstacle
    {
        public ObstacleType ObstacleType { get; }
        public ICoordinate Coordinate { get; }
    }
}