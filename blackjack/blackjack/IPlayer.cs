namespace blackjack
{
    internal interface IPlayer
    {
        public void DecideMove();
        public void Hit();
        public void Stay();
    }
}