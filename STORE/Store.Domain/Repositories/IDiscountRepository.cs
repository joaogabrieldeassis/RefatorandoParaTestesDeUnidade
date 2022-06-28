namespace Store.Domain.Entities
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}