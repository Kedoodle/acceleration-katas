using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Order
    {
        public DateTime DueDate { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int OrderNumber { get; set; }
    }
}