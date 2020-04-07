namespace MontyHall
{
    public class PrizeDoor : IDoor
    {
        public bool HasPrize()
        {
            return true;
        }

        public bool HasGoat()
        {
            return false;
        }
    }
}