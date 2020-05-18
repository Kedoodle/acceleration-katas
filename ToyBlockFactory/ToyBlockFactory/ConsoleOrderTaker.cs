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
            var order = new Order
            {
                CustomerName = AskString("Please input your Name: "),
                CustomerAddress = AskString("Please input your Address: "),
                DueDate = AskDueDate("Please input your Due Date: "),
                Blocks = new List<Block>()
            };
            _output.WriteLine();
            
            foreach (Shape shape in Enum.GetValues(typeof(Shape)))
            {
                foreach (Colour colour in Enum.GetValues(typeof(Colour)))
                {
                    var numberOfBlocks = AskNumberOfBlocks($"Please input the number of {colour} {shape}s: ");
                    for (var i = 0; i < numberOfBlocks; i++)
                    {
                        order.Blocks.Add(new Block(shape, colour));
                    }
                }
                _output.WriteLine();
            }
            
            return order;
        }

        private string AskString(string prompt)
        {
            _output.Write(prompt);
            return _input.ReadLine();
        }

        private DateTime AskDueDate(string prompt)
        {
            _output.Write(prompt);

            DateTime dueDate;
            while (!DateTime.TryParse(_input.ReadLine(), out dueDate))
            {
                _output.Write("Invalid date! " + prompt);
            }

            return dueDate;
        }

        private int AskNumberOfBlocks(string prompt)
        {
            _output.Write(prompt);
            
            var input = _input.ReadLine();
            int numberOfBlocks;
            while (!int.TryParse(input, out numberOfBlocks) || numberOfBlocks < 0)
            {
                if (input == "") return 0;
                
                _output.Write("Invalid positive integer! " + prompt);
                input = _input.ReadLine();
            }

            return numberOfBlocks;
        }
    }
}
