namespace blackjack
{
    internal interface IPlayer
    {
        public void MakeMove(Move move);
        public void Hit();
        public void Stay();
    }
}