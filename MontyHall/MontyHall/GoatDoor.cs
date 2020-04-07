namespace MontyHall
{
    public class GoatDoor : IDoor
    {
        public bool HasPrize()
        {
            return false;
        }

        public bool HasGoat()
        {
            return true;
        }
    }
}