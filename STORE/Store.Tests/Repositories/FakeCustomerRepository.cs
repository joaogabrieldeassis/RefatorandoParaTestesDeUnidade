using Store.Domain.Entities;

namespace Stores.Tests.Entities
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Bruce Wayne", "joao@gmail.com");

            return null;
        }
    }
}