namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal discountAmount, DateTime expireDate)
        {
            DiscountAmount = discountAmount;
            ExpireDate = expireDate;
        }

        public decimal DiscountAmount { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }
        public decimal Value()
        {
            if (IsValid())
                return DiscountAmount;

            else
                return 0;
        }
    }
}