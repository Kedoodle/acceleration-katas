namespace MarsRover
{
    public interface ICoordinate
    {
        int X { get; }
        int Y { get; }
        ObstacleType Obstacle { get; set; }

        public bool IsEmpty();
    }
}
