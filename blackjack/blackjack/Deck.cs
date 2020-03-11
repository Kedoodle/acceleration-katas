using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Deck
    {
        private readonly Random _random = new Random();
        private List<Card> _cards;

        public Deck()
        {
            Initialise();
            Shuffle();
        }

        private void Initialise()
        {
            _cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                _cards.Append(new Card(rank, suit));
        }

        private void Shuffle() // Shuffles the deck using the Fisher-Yates shuffle algorithm
        {
            for (var i = _cards.Count; i > 1; i--)
            {
                var k = _random.Next(i + 1);
                var value = _cards[k];
                _cards[k] = _cards[i];
                _cards[i] = value;
            }
        }

        public Card Draw()
        {
            var card = _cards.FirstOrDefault();
            _cards.Remove(card);
            return card;
        }
    }
}