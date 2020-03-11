using System;
using System.Linq;

namespace blackjack
{
    public class ConsoleGameRenderer : IGameRenderer
    {
        public void DisplayGame(Game game)
        {
            switch (game.State)
            {
                case GameState.Initialisation:
                    break;
                case GameState.PlayerMove:
                    Console.WriteLine($"You are at {game.Player.Hand.Score}\n" +
                                      $"with the hand {game.Player.Hand}");
                    break;
                case GameState.PlayerHit:
                    Console.WriteLine($"You draw {game.Player.Hand.Cards.Last()}");
                    break;
                case GameState.PlayerBust:
                    Console.WriteLine($"You bust at {game.Player.Hand.Score}\n" +
                                      $"with the hand {game.Player.Hand}");
                    break;
                case GameState.PlayerBlackjack:
                    Console.WriteLine("You hit the blackjack\n" +
                                      $"with the hand {game.Player.Hand}");
                    break;
                case GameState.DealerMove:
                    Console.WriteLine($"Dealer is at {game.Dealer.Hand.Score}\n" +
                                      $"with the hand {game.Dealer.Hand}");
                    break;
                case GameState.DealerHit:
                    Console.WriteLine($"Dealer draws {game.Dealer.Hand.Cards.Last()}");
                    break;
                case GameState.DealerBlackjack:
                    Console.WriteLine("Dealer hit the blackjack\n" +
                                      $"with the hand {game.Dealer.Hand}");
                    break;
                case GameState.DealerBust:
                    Console.WriteLine($"Dealer bust at {game.Dealer.Hand.Score}\n" +
                                      $"with the hand {game.Dealer.Hand}");
                    break;
                case GameState.Tie:
                    Console.WriteLine("The game was a tie!");
                    break;
                case GameState.PlayerWin:
                    Console.WriteLine("You beat the dealer!");
                    break;
                case GameState.DealerWin:
                    Console.WriteLine("Dealer wins!");
                    break;
                case GameState.Exit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine();
        }
    }
    
    public interface IGameRenderer
    {
        public void DisplayGame(Game game);
    }
}