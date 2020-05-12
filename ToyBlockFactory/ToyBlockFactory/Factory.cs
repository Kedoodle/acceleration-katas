using System.Collections.Generic;
using System.IO;

namespace ToyBlockFactory
{
    public class Factory
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public Factory(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;
        }

        public void Start()
        {
            _output.WriteLine("Welcome to the Toy Block Factory!");
        }
    }
}