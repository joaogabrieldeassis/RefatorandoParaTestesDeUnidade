namespace Store.Domain.Entities
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> Ids);
    }
}