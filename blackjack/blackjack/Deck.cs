using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Deck
    {
        private readonly Random _random = new Random();

        public Deck()
        {
            Cards = new List<Card>();
            foreach (var suit in Suits.)
            {
                foreach (Rank rank in typeof(Rank).GetEnumValues())
                {
                    Cards.Append(new Card(rank, suit));
                }
            }
            Shuffle();
        }

        private List<Card> Cards { get; }

        private void Shuffle() // Shuffles the deck using the Fisher-Yates shuffle algorithm
        {
            for (var i = Cards.Count; i > 1; i--)
            {
                var k = _random.Next(i + 1);
                var value = Cards[k];
                Cards[k] = Cards[i];
                Cards[i] = value;
            }
        }

        public Card Draw()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);
            return card;
        }
    }
}