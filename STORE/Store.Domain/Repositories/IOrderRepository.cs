namespace Store.Domain.Entities
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}