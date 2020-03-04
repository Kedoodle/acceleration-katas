using System.Linq;
using abc;
using Xunit;

namespace abc_tests
{
    public class AcceptanceTests
    {
        [Theory]
        [InlineData("A", true)]
        [InlineData("BARK", true)]
        [InlineData("BOOK", false)]
        [InlineData("TREAT", true)]
        [InlineData("COMMON", false)]
        [InlineData("SQUAD", true)]
        [InlineData("CONFUSE", true)]
        public void CanMakeWord_AcceptanceWords_ReturnsExpectedBoolean(string wordToBuild, bool expected)
        {
            var wordBuilder = CreateSampleWordBuilder();

            var actual = wordBuilder.CanMakeWord(wordToBuild);

            Assert.Equal(expected, actual);
        }

        private WordBuilder CreateSampleWordBuilder()
        {
            var blocks = new []
            {
                ('B', 'O'),
                ('X', 'K'),
                ('D', 'Q'),
                ('C', 'P'),
                ('N', 'A'),
                ('G', 'T'),
                ('R', 'E'),
                ('T', 'G'),
                ('Q', 'D'),
                ('F', 'S'),
                ('J', 'W'),
                ('H', 'U'),
                ('V', 'I'),
                ('A', 'N'),
                ('O', 'B'),
                ('E', 'R'),
                ('F', 'S'),
                ('L', 'Y'),
                ('P', 'C'),
                ('Z', 'M')
            }.Select(letters => new Block(letters));
            var sampleWordBuilder = new WordBuilder(blocks);
            return sampleWordBuilder;
        }
    }
}