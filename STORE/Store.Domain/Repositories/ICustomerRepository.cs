namespace Store.Domain.Entities
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}