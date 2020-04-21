namespace MarsRover
{
    public struct Location : ILocation
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
            Obstacle = ObstacleType.None;
        }
        
        public int X { get; }
        public int Y { get; }
        public ObstacleType Obstacle { get; set; }
        
        public bool HasObstacle()
        {
            return !(Obstacle is ObstacleType.None);
        }
    }
}
