using Store.Domain.Entities;

namespace Stores.Tests.Entities
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
        }
    }
}