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

        public IEnumerable<char> GetCharacters()
        {
            return new List<char> {X, Y};
        }
        
        public bool HasLetter(char letter)
        {
            return X == letter || Y == letter;
        }
    }
}