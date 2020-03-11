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