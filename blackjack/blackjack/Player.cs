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

        public void Hit(Card card)
        {
            Hand.AddCard(card);
        }
    }
}