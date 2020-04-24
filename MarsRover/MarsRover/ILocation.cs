namespace MarsRover
{
    public interface ILocation
    {
        int X { get; }
        int Y { get; }
        ObstacleType Obstacle { get; set; }

        public bool HasObstacle();
    }
}
