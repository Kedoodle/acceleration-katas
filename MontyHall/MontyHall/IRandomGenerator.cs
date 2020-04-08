using System.Collections.Generic;

namespace MontyHall
{
    public interface IRandomGenerator
    {
        public DoorIndex NextPrizeDoorIndex();
        public DoorIndex NextContestantChoiceDoorIndex();
        public DoorIndex SelectGoatDoorIndex(List<DoorIndex> goatDoorIndices);
    }
}