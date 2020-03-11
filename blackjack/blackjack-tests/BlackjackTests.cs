using System;
using System.Linq;
using blackjack;
using Xunit;

namespace blackjack_tests
{
    public class BlackjackTests
    {
        [Fact]
        public void CardToString_AceOfHearts_ReturnsRankAndSuit()
        {
            const string expected = "[ACE, HEARTS]";

            var card = new Card(Rank.Ace, Suit.Hearts);
            var actual = card.ToString();

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void HandToString_AceOfHeartsFourOfHeartsQueenOfSpades_ReturnsRanksAndSuits()
        {
            const string expected = "[[ACE, HEARTS], [FOUR, HEARTS], [QUEEN, HEARTS]]";
            
            var hand = new Hand();
            hand.AddCard(new Card(Rank.Ace, Suit.Hearts));
            hand.AddCard(new Card(Rank.Four, Suit.Hearts));
            hand.AddCard(new Card(Rank.Queen, Suit.Hearts));
            var actual = hand.ToString();

            Assert.Equal(expected, actual);
        }
    }
}