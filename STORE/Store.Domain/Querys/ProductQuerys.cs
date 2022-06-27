using System.Linq.Expressions;
using Store.Domain.Entities;

namespace Store.Domain.Querys
{
    public static class ProductQuerys
    {
        public static Expression<Func<Product, bool>> GeActiveProducts()
        {
            return x => x.Active;
        }
    }
}