namespace MarsRover
{
    public class Boulder : IObstacle
    {
        public Boulder(ICoordinate coordinate)
        {
            ObstacleType = ObstacleType.Boulder;
            Coordinate = coordinate;
        }

        public ObstacleType ObstacleType { get; }
        public ICoordinate Coordinate { get; }
    }
}
