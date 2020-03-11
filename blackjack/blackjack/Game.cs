namespace blackjack
{
    public class Game
    {
        private GameState _state = GameState.Initialisation;
        private Dealer _dealer = new Dealer();
        private Deck _deck = new Deck();
        private Player _player = new Player();
        private IGameRenderer _gameRenderer;
        private IUserInputGetter _userInputGetter;

        public Game(IGameRenderer gameRenderer, IUserInputGetter userInputGetter)
        {
            _gameRenderer = gameRenderer;
            _userInputGetter = userInputGetter;
        }

        public void Start()
        {
            DealInitialCards();
            _state = GameState.PlayerMove;
            while (_state == GameState.PlayerMove)
            {
                _gameRenderer.DisplayGame(_state);
                
            }
            
        }

        private void DealInitialCards()
        {
            _player.Hand.AddCard(_deck.Draw());
            _dealer.Hand.AddCard(_deck.Draw());
            _player.Hand.AddCard(_deck.Draw());
            _dealer.Hand.AddCard(_deck.Draw());
        }
    }

    public enum GameState
    {
        Initialisation,
        PlayerMove,
        PlayerBust,
        DealerMove,
        DealerBust,
        Tie
    }
}