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

            var card = new Card(Ranks.Ace, Suits.Hearts);
            var actual = card.ToString();

            Assert.Equal(expected, actual);
        }
    }
}