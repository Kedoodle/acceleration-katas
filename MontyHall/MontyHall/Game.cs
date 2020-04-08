using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall
{
    public class Game
    {
        public Game(IRandomGenerator randomGenerator)
        {
            RandomGenerator = randomGenerator;
            InitialiseDoors();
        }

        private IRandomGenerator RandomGenerator { get; }

        public List<IDoor> Doors { get; } = new List<IDoor>();
        public DoorIndex ContestantChoiceDoorIndex { get; set; }
        public DoorIndex GoatRevealDoorIndex { get; set; }
        public ContestantDecision ContestantDecision { get; set; }

        private void InitialiseDoors()
        {
            Doors.Add(new GoatDoor());
            Doors.Add(new GoatDoor());
            Doors.Insert((int) RandomGenerator.NextPrizeDoorIndex(), new PrizeDoor());
        }

        public void RevealGoatDoor()
        {
            var remainingDoorIndices = Enum.GetValues(typeof(DoorIndex)).Cast<DoorIndex>().Where(i => i != ContestantChoiceDoorIndex);
            var goatDoorIndices = remainingDoorIndices.Where(i => GetDoor(i).HasGoat());
            GoatRevealDoorIndex = RandomGenerator.SelectGoatDoorIndex(goatDoorIndices.ToList());
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