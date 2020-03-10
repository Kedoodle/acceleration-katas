namespace blackjack
{
    public struct Card
    {
        public string Rank { get; }
        public string Suit { get; }

        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"[{Rank.ToUpper()}, {Suit.ToUpper()}]";
        }
    }

    public static class Ranks
    {
        public const string Ace = "Ace";
        public const string Two = "Two";
        public const string Three = "Three";
        public const string Four = "Four";
        public const string Five = "Five";
        public const string Six = "Six";
        public const string Seven = "Seven";
        public const string Eight = "Eight";
        public const string Nine = "Nine";
        public const string Ten = "Ten";
        public const string Jack = "Jack";
        public const string Queen = "Queen";
        public const string King = "King";
    }

    public static class Suits
    {
        public const string Clubs = "Clubs";
        public const string Diamonds = "Diamonds";
        public const string Hearts = "Hearts";
        public const string Spades = "Spades";
    }
}