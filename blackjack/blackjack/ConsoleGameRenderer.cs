using System;
using System.Linq;

namespace blackjack
{
    public class ConsoleGameRenderer : IGameRenderer
    {
        public void DisplayGame(Game game)
        {
            Console.WriteLine(game.State.ToString());
            switch (game.State)
            {
                case GameState.Initialisation:
                    break;
                case GameState.PlayerMove:
                    Console.WriteLine($"You are at currently at {game.Player.Hand.Score}\n" +
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
                    Console.WriteLine($"You hit the blackjack\n" +
                                      $"with the hand {game.Player.Hand}");
                    break;
                case GameState.DealerMove:
                    break;
                case GameState.DealerBust:
                    break;
                case GameState.Tie:
                    break;
                case GameState.PlayerWin:
                    break;
                case GameState.Exit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    public interface IGameRenderer
    {
        public void DisplayGame(Game game);
    }
}