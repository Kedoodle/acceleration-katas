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

        public bool HasLetter(char letter)
        {
            return X == letter || Y == letter;
        }
    }
}