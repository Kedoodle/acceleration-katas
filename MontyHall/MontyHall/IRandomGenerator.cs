namespace MontyHall
{
    public interface IRandomGenerator
    {
        public DoorIndex NextPrizeDoorIndex();
        public DoorIndex NextContestantChoiceDoorIndex();
        public DoorIndex NextGoatRevealDoorIndex();
        public ContestantDecision NextContestantDecision();
    }
}