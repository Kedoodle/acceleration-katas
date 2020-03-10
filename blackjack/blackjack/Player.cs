namespace blackjack
{
    internal class Player : IPlayer
    {
        public Hand Hand { get; private set; }
        public void Hit()
        {
            throw new System.NotImplementedException();
        }

        public void Stay()
        {
            throw new System.NotImplementedException();
        }
    }
}