namespace MarsRover
{
    public interface IRover
    {
        public ILocation Location { get; }
        public Direction Direction { get; }
        public void TurnLeft();
        public void TurnRight();
        public void MoveForward();
        public void MoveBackward();
    }
}