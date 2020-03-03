using System.Collections.Generic;
using System.Linq;

namespace abc
{
    public class WordBuilder
    {
        private readonly IEnumerable<Block> _blocks;

        public WordBuilder(IEnumerable<Block> blocks)
        {
            _blocks = blocks;
        }

        public bool CanMakeWord(string word)
        {
            if (word.Length == 0) return true;
            var availableBlocks = new List<Block>(_blocks);
            foreach (var letter in word)
            {
                var match = availableBlocks.FirstOrDefault(block => block.HasLetter(letter));
                if (match != null)
                {
                    availableBlocks.Remove(match);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}