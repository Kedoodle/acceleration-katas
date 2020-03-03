using System;
using System.Collections;
using System.Collections.Generic;

namespace abc
{
    public class Block
    {
        public Block((char, char) letters)
        {
            var (x, y) = letters;
            (X, Y) = (char.ToUpper(x), char.ToUpper(y));
        }
        
        public Block(char x, char y)
        {
            X = char.ToUpper(x);
            Y = char.ToUpper(y);
        }

        private char X { get;}
        private char Y { get; }

        public IEnumerable<char> getCharacters()
        {
            return new List<char> {X, Y};
        }
    }
}