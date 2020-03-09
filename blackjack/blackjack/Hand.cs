using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Hand
    {
        private int Score { get; set; }
        private IEnumerable<Card> Cards { get; }

        public void Hit(Deck deck)
        {
            Cards.Append(deck.Draw());
            Score = HandCalculator.Score(this);
        }
    }

    public static class HandCalculator()
    {
    }
}