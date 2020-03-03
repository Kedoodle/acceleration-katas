using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace abc
{
    public class WordBuilder
    {
        private IEnumerable<Block> _blocks;
        private IEnumerable<char> _characters;

        public WordBuilder(IEnumerable<Block> blocks)
        {
            _blocks = blocks;
            _characters = GetCharactersFromBlocks(_blocks);
        }

        private static IEnumerable<char> GetCharactersFromBlocks(IEnumerable<Block> blocks)
        {
            return blocks.SelectMany(block => block.getCharacters());
        }

        public bool CanMakeWord(string wordToBuild)
        {
            var availableCharacters = new List<char>(_characters);
            return wordToBuild.All(character => availableCharacters.Remove(character));
        }
    }
}