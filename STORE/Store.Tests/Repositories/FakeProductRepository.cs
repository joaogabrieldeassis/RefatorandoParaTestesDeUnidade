using System;
using System.Collections.Generic;
using Store.Domain.Entities;

namespace Stores.Tests.Entities
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> Ids)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product("Product 1", 10, true));
            products.Add(new Product("Product 2", 10, true));
            products.Add(new Product("Product 3", 10, true));
            products.Add(new Product("Product 4", 10, false));
            products.Add(new Product("Product 5", 10, false));
            return products;
        }
    }
}