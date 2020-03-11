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

        public void DecideMove()
        {
            throw new NotImplementedException();
        }

        public void Hit(Card card)
        {
            Hand.AddCard(card);
        }

        public void Stay()
        {
            throw new NotImplementedException();
        }
    }
}