using System;

namespace blackjack
{
    public class Game
    {
        private readonly Deck _deck = new Deck();
        private readonly IGameRenderer _gameRenderer;
        private readonly IUserInputGetter _userInputGetter;

        public Game(IGameRenderer gameRenderer, IUserInputGetter userInputGetter)
        {
            _gameRenderer = gameRenderer;
            _userInputGetter = userInputGetter;
        }
        
        public GameState State { get; private set; } = GameState.Initialisation;
        public Dealer Dealer { get; private set; } = new Dealer();
        public Player Player { get; } = new Player();

        public void Start()
        {
            while (State != GameState.Exit)
            {
                switch (State)
                {
                    case GameState.Initialisation:
                    {
                        DealInitialCards();
                        State = Player.Hand.IsBlackjack() ? GameState.PlayerBlackjack : GameState.PlayerMove;
                        break;
                    }
                    case GameState.PlayerMove:
                        if (_userInputGetter.GetMove() == Move.Hit)
                        {
                            Player.Hit(_deck.Draw());
                            State = GameState.PlayerHit;
                        }
                        else
                        {
                            State = GameState.DealerMove;
                        }
                        break;
                    case GameState.PlayerHit:
                        if (Player.Hand.IsBlackjack())
                        {
                            State = GameState.PlayerBlackjack;
                        }
                        else if (Player.Hand.IsBust())
                        {
                            State = GameState.PlayerBust;
                        }
                        else
                        {
                            State = GameState.PlayerMove;
                        }
                        break;
                    case GameState.PlayerBlackjack:
                        State = Dealer.Hand.IsBlackjack() ? GameState.Tie : GameState.DealerMove;
                        break;
                    case GameState.PlayerBust:
                        State = GameState.DealerWin;
                        break;
                    case GameState.DealerMove:
                        
                        if (Dealer.GetMove() == Move.Hit)
                        {
                            Dealer.Hit(_deck.Draw());
                            State = GameState.DealerHit;
                        }
                        else
                        {
                            if (Dealer.Hand.Score == Player.Hand.Score)
                            {
                                State = GameState.Tie;
                            }
                            else
                            {
                                State = Dealer.Hand.Score > Player.Hand.Score
                                    ? GameState.DealerWin
                                    : GameState.PlayerWin;
                            }
                        }
                        break;
                    case GameState.DealerHit:
                        if (Dealer.Hand.IsBlackjack())
                        {
                            State = GameState.DealerBlackjack;
                        }
                        else if (Dealer.Hand.IsBust())
                        {
                            State = GameState.DealerBust;
                        }
                        else
                        {
                            State = GameState.DealerMove;
                        }
                        break;
                    case GameState.DealerBlackjack:
                        State = Player.Hand.IsBlackjack() ? GameState.Tie : GameState.DealerWin;
                        break;
                    case GameState.DealerBust:
                        State = GameState.PlayerWin;
                        break;
                    case GameState.Tie:
                        State = GameState.Exit;
                        break;
                    case GameState.PlayerWin:
                        State = GameState.Exit;
                        break;
                    case GameState.DealerWin:
                        State = GameState.Exit;
                        break;
                    case GameState.Exit:
                        Environment.Exit(1);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _gameRenderer.DisplayGame(this);
            }
            
        }

        private void DealInitialCards()
        {
            Player.Hand.AddCard(_deck.Draw());
            Dealer.Hand.AddCard(_deck.Draw());
            Player.Hand.AddCard(_deck.Draw());
            Dealer.Hand.AddCard(_deck.Draw());
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
        PlayerBlackjack,
        PlayerHit,
        DealerWin,
        DealerHit,
        DealerBlackjack
    }
    
    public enum Move
    {
        Stay,
        Hit
    }
}