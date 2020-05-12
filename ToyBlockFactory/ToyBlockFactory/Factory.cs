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

        public List<Order> Orders { get; set; }

        public void Start()
        {
            _output.WriteLine("Welcome to the Toy Block Factory!");
        }

        public void TakeOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}