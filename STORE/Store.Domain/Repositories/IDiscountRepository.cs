namespace Store.Domain.Entities
{
    public interface IDiscountRepository
    {
        Discount get(string code);
    }
}