using System.Linq;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class FactoryShould
    {
        [Fact]
        public void AssignOrderNumbers()
        {
            var mockOrderTaker = new Mock<IOrderTaker>();
            mockOrderTaker.SetupSequence(m => m.TakeOrder())
                .Returns(new Order())
                .Returns(new Order());
            var mockReportGenerator = Mock.Of<IReportGenerator>();
            var factory = new Factory(mockOrderTaker.Object, mockReportGenerator);
            
            factory.CreateOrder();
            factory.CreateOrder();
            
            Assert.NotEqual(factory.Orders.First().OrderNumber, factory.Orders.Last().OrderNumber);
        }
    }
}
