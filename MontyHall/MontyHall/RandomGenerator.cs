using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall
{
    class RandomGenerator : IRandomGenerator
    {
        private Random _random = new Random();
        
        public DoorIndex NextPrizeDoorIndex()
        {
            return GetRandomDoorIndex();
        }

        public DoorIndex NextContestantChoiceDoorIndex()
        {
            return GetRandomDoorIndex();
        }

        public DoorIndex SelectGoatDoorIndex(List<DoorIndex> goatDoorIndices)
        {
            return goatDoorIndices[_random.Next(goatDoorIndices.Count)];
        }

        private DoorIndex GetRandomDoorIndex()
        {
            var doorIndices = Enum.GetValues(typeof(DoorIndex)).Cast<DoorIndex>().ToList();
            return doorIndices[_random.Next(doorIndices.Count)];
        }
    }
}