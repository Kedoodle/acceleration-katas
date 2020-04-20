namespace MarsRover
{
    public class Tree : IObstacle
    {
        public Tree(ICoordinate coordinate)
        {
            ObstacleType = ObstacleType.Tree;
            Coordinate = coordinate;
        }

        public ObstacleType ObstacleType { get; }
        public ICoordinate Coordinate { get; }
    }
}
