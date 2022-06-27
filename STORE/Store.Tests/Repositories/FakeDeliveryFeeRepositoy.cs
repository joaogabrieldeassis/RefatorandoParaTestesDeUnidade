using Store.Domain.Entities;

namespace Stores.Tests.Entities
{
    public class FakeDeliveryFeeRepositoy : IDeliveryFeeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}