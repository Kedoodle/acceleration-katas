using System;

namespace blackjack
{
    public class Player : IPlayer
    {
        private IUserInputGetter _userInputGetter;

        public Player()
        {
            Hand = new Hand();
        }

        public Hand Hand { get; }

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