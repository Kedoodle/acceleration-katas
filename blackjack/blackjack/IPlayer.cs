namespace blackjack
{
    internal interface IPlayer
    {
        public void MakeMove();
        public void Hit();
        public void Stay();
    }
}