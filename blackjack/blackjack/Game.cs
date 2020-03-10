namespace blackjack
{
    public class Game
    {

        private Deck _deck = new Deck();
        private Dealer _dealer = new Dealer();
        private Player _player = new Player();
        
        public void Start()
        {
            
        }
        
    }

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

    internal class Dealer : IPlayer
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

    internal interface IPlayer
    {
        public void Hit();
        public void Stay();
    }
}