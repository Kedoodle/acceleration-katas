using System;
using System.Linq;

namespace abc
{
    class Program
    {
        static void Main(string[] args)
        {
            var blocks = new[]
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

            var words = new[]
            {
                "A",
                "BARK",
                "BOOK",
                "TREAT",
                "COMMON",
                "SQUAD",
                "CONFUSE"
            };
            
            var wordBuilder = new WordBuilder(blocks);

            foreach (var word in words)
            {
                Console.WriteLine("We are {0} to spell \"{1}\" with the given collection of blocks.", wordBuilder.CanMakeWord(word) ? "able" : "unable", word);
            }
            
        }
    }
}