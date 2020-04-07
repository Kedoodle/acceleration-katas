using System.Collections.Generic;

namespace MontyHall
{
    public class Game
    {
        public List<IDoor> Doors { get; set; } = new List<IDoor>();

        public Game(DoorIndex prizeDoorIndex)
        {
            InitialiseDoors(prizeDoorIndex);
        }

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
    }
}