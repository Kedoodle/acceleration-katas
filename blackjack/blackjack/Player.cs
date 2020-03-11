using System;

namespace blackjack
{
    public class Player : IPlayer
    {
        public Player()
        {
            Hand = new Hand();
        }

        public Hand Hand { get; }

        public void MakeMove(Move move)
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void Stay()
        {
            throw new NotImplementedException();
        }
    }

    public enum Move
    {
        Stay,
        Hit
    }
}