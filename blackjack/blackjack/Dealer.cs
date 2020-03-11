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

        public Move DecideMove()
        {
            return Hand.Score < 17 ? Move.Hit : Move.Stay;
        }

        public void Hit(Card card)
        {
            Hand.AddCard(card);
        }
    }
}