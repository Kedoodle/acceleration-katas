using System;
using System.Collections.Generic;
using System.IO;

namespace ToyBlockFactory
{
    public class ConsoleOrderTaker : IOrderTaker
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public ConsoleOrderTaker(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;
        }

        public Order TakeOrder()
        {
            var order = new Order();
            _output.WriteLine("Please input your Name: ");
            order.CustomerName = _input.ReadLine();
            _output.WriteLine("Please input your Address: ");
            order.CustomerAddress = _input.ReadLine();
            _output.WriteLine("Please input your Due Date: ");
            order.DueDate = DateTime.Parse(_input.ReadLine());
            _output.WriteLine();
            
            var blocks = new List<Block>();
            foreach (Shape shape in Enum.GetValues(typeof(Shape)))
            {
                foreach (Colour colour in Enum.GetValues(typeof(Colour)))
                {
                    _output.WriteLine($"Please input the number of {colour} {shape}s: ");
                    if (!int.TryParse(_input.ReadLine(), out var n)) n = 0;
                    for (var i = 0; i < n; i++)
                    {
                        blocks.Add(new Block(shape, colour));
                    }
                }
                _output.WriteLine();
            }
            order.Blocks = blocks;
            
            return order;
        }
    }
}