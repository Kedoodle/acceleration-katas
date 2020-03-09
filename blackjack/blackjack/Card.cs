namespace blackjack
{
    public struct Card
    {
        private Rank Rank { get; }
        private Suit Suit { get; }
        
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }
}