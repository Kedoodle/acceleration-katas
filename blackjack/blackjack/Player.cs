using System;

namespace blackjack
{
    public class Player : IPlayer
    {
        private IUserInputGetter _userInputGetter;

        public Player(IUserInputGetter userInputGetter)
        {
            Hand = new Hand();
            _userInputGetter = userInputGetter;
        }

        public Hand Hand { get; }

        public void MakeMove()
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