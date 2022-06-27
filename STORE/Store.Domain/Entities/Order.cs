using System.Diagnostics.Contracts;
using Flunt.Validations;
using Store.Domain.Enuns;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        private IList<OrderItem> _itemns;
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {
            AddNotifications(new Contract<Order>()
                    .Requires()
                    .IsNotNull(customer, "Customer", "Cliente invalido")
            );
            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _itemns = new List<OrderItem>();
        }
        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);
            if (item.IsValid)
                _itemns.Add(item);
        }
        public decimal Total()
        {
            decimal total = 0;
            foreach (var receiveItem in _itemns)
            {
                total += receiveItem.TotalPricyAndTotalQuantity();
            }
            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;
            return total;
        }
        public void Pay(decimal amount)
        {
            if (amount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }
        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
        }
        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IReadOnlyCollection<OrderItem> Itemns { get { return _itemns.ToArray(); } }
        public decimal DeliveryFee { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }
    }
}