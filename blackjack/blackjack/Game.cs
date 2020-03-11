using System;

namespace blackjack
{
    public class Game
    {
        public GameState State { get; private set; } = GameState.Initialisation;
        private Dealer _dealer = new Dealer();
        private Deck _deck = new Deck();
        public Player Player { get; } = new Player();
        private IGameRenderer _gameRenderer;
        private IUserInputGetter _userInputGetter;

        public Game(IGameRenderer gameRenderer, IUserInputGetter userInputGetter)
        {
            _gameRenderer = gameRenderer;
            _userInputGetter = userInputGetter;
        }

        public void Start()
        {
            while (State != GameState.Exit)
            {
                _gameRenderer.DisplayGame(this);
                switch (State)
                {
                    case GameState.Initialisation:
                    {
                        DealInitialCards();
                        State = GameState.PlayerMove;
                        break;
                    }
                    case GameState.PlayerMove:
                        var move = _userInputGetter.GetMove();
                        if (move == Move.Hit)
                        {
                            Player.Hit(_deck.Draw());
                            if (Player.Hand.IsBlackjack())
                            {
                                State = GameState.PlayerBlackjack;
                            }
                            else if (Player.Hand.IsBust())
                            {
                                State = GameState.PlayerBust;
                            }
                        }
                        else
                        {
                            State = GameState.DealerMove;
                        }
                        break;
                    case GameState.PlayerBust:
                        State = GameState.Exit;
                        break;
                    case GameState.DealerMove:
                        State = GameState.Exit;
                        break;
                    case GameState.DealerBust:
                        State = GameState.Exit;
                        break;
                    case GameState.Tie:
                        State = GameState.Exit;
                        break;
                    case GameState.PlayerWin:
                        State = GameState.Exit;
                        break;
                    case GameState.Exit:
                        Environment.Exit(1);
                        break;
                    case GameState.PlayerBlackjack:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
        }

        private void DealInitialCards()
        {
            Player.Hand.AddCard(_deck.Draw());
            _dealer.Hand.AddCard(_deck.Draw());
            Player.Hand.AddCard(_deck.Draw());
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
        Tie,
        PlayerWin,
        Exit,
        PlayerBlackjack
    }
    
    public enum Move
    {
        Stay,
        Hit
    }
}