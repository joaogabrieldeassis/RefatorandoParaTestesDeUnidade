namespace Store.Domain.Entities
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipcode);
    }
}