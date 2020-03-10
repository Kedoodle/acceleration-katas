using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Hand
    {
        public int Score { get; set; }
        public IEnumerable<Card> Cards { get; }

        public void Hit(Deck deck)
        {
            Cards.Append(deck.Draw());
            Score = HandScoreCalculator.Score(this);
        }
    }

    public static class HandScoreCalculator()
    {
        public static int Score(Hand hand)
        {
            var score = hand.Cards.Where(card => card.Rank != Ranks.Ace).Sum(card => _rankScoreDictionary[card.Rank]); // Score non-ace cards
            var aces = hand.Cards.Count(card => card.Rank == Ranks.Ace);
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

        private static Dictionary<string, int> _rankScoreDictionary = new Dictionary<string, int>
        {
            {Ranks.Two, 2},
            {Ranks.Three, 3},
            {Ranks.Four, 4},
            {Ranks.Five, 5},
            {Ranks.Six, 6},
            {Ranks.Seven, 7},
            {Ranks.Eight, 8},
            {Ranks.Nine, 9},
            {Ranks.Ten, 10},
            {Ranks.Jack, 10},
            {Ranks.Queen, 10},
            {Ranks.King, 10}
        };
    }
}