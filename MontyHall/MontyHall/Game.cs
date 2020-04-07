using System.Collections.Generic;

namespace MontyHall
{
    public class Game
    {
        public Game(DoorIndex prizeDoorIndex)
        {
            InitialiseDoors(prizeDoorIndex);
        }

        public List<IDoor> Doors { get; } = new List<IDoor>();
        public DoorIndex ContestantChoiceDoorIndex { get; set; }
        public DoorIndex GoatRevealDoorIndex { get; set; }
        public ContestantDecision ContestantDecision { get; set; }
        
        private void InitialiseDoors(DoorIndex prizeDoorIndex)
        {
            Doors.Add(new GoatDoor());
            Doors.Add(new GoatDoor());
            Doors.Insert((int) prizeDoorIndex, new PrizeDoor());
        }

        public IDoor GetDoor(DoorIndex index)
        {
            return Doors[(int) index];
        }

        public bool DidContestantWin()
        {
            return DidContestantStickWithWinningChoice() || DidContestantSwitchFromLosingChoice();
        }

        private bool DidContestantStickWithWinningChoice()
        {
            return GetDoor(ContestantChoiceDoorIndex).HasPrize() && ContestantDecision == ContestantDecision.Stick;
        }

        private bool DidContestantSwitchFromLosingChoice()
        {
            return !GetDoor(ContestantChoiceDoorIndex).HasPrize() && ContestantDecision == ContestantDecision.Switch;
        }
    }
}