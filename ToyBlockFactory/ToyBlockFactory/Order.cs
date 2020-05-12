using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Order
    {
        public DateTime DueDate { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
    }
}