using System.Collections.Generic;
using System.Linq;
using ToyBlockFactory.OrderTaker;
using ToyBlockFactory.ReportGenerator;

namespace ToyBlockFactory
{
    public class Factory
    {
        private int _nextOrderNumber = 1;
        private readonly IOrderTaker _orderTaker;
        private readonly IReportGenerator _reportGenerator;

        public Factory(IOrderTaker orderTaker, IReportGenerator reportGenerator)
        {
            _orderTaker = orderTaker;
            _reportGenerator = reportGenerator;
        }

        public List<Order> Orders { get; } = new List<Order>();

        public void CreateOrder()
        {
            var order = _orderTaker.TakeOrder();
            order.OrderNumber = _nextOrderNumber++;
            Orders.Add(order);
        }

        public void GenerateReports(int orderNumber)
        {
            var order = Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            _reportGenerator.Generate(Report.Invoice, order);
            _reportGenerator.Generate(Report.CuttingList, order);
            _reportGenerator.Generate(Report.Painting, order);
        }
    }
}