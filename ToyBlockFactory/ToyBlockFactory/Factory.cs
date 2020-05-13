using System.Collections.Generic;
using System.IO;

namespace ToyBlockFactory
{
    public class Factory
    {
        private readonly IOrderTaker _orderTaker;
        private readonly IReportGenerator _reportGenerator;

        public Factory(IOrderTaker orderTaker, IReportGenerator reportGenerator)
        {
            _orderTaker = orderTaker;
            _reportGenerator = reportGenerator;
        }

        public List<Order> Orders { get; set; }
    }
}