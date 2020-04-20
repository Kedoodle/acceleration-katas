namespace MarsRover
{
    public interface IRover
    {
        public ICoordinate Coordinate { get; }
        public Direction Direction { get; }
        public void TurnLeft();
        public void TurnRight();
        public void MoveForward();
        public void MoveBackward();
    }
}