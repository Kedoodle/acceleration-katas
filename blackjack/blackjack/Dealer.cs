using System;

namespace blackjack
{
    public class Dealer : IPlayer
    {
        public Dealer()
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
}