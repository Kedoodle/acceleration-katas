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
            var move = _userInputGetter.GetMove();
            switch (move)
            {
                case Move.Hit:
                    Hit();
                    break;
                case Move.Stay:
                    Stay();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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