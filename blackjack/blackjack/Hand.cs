using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Hand
    {
        public int Score { get; private set; }
        public IEnumerable<Card> Cards { get; private set; }

        public Hand()
        {
            Score = 0;
            Cards = new List<Card>();
        }
        
        public void Hit(Deck deck)
        {
            Cards.Append(deck.Draw());
            Score = HandScoreCalculator.Score(this);
        }

        public bool IsBlackjack()
        {
            return Score == 21;
        }

        public bool IsBust()
        {
            return Score > 21;
        }
    }

    public static class HandScoreCalculator
    {
        public static int Score(Hand hand)
        {
            var score = hand.Cards.Where(card => card.Rank != Rank.Ace).Sum(card => _rankScoreDictionary[card.Rank]); // Score non-ace cards
            var aces = hand.Cards.Count(card => card.Rank == Rank.Ace);
            if (score > 10)
            {
                score += aces;
            }
            else if (score == 11 - aces)
            {
                score = 21;
            }
            else
            {
                score += 11 + aces - 1;
            }
            return score;
        }

        private static Dictionary<Rank, int> _rankScoreDictionary = new Dictionary<Rank, int>
        {
            {Rank.Two, 2},
            {Rank.Three, 3},
            {Rank.Four, 4},
            {Rank.Five, 5},
            {Rank.Six, 6},
            {Rank.Seven, 7},
            {Rank.Eight, 8},
            {Rank.Nine, 9},
            {Rank.Ten, 10},
            {Rank.Jack, 10},
            {Rank.Queen, 10},
            {Rank.King, 10}
        };
    }
}