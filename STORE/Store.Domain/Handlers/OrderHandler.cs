using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interface;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customer;
        private readonly IDeliveryFeeRepository _delivery;
        private readonly IDiscountRepository _discount;
        private readonly IOrderRepository _ordeer;
        private readonly IProductRepository _product;

        public OrderHandler(ICustomerRepository customer, IDeliveryFeeRepository delivery, IDiscountRepository discount, IOrderRepository ordeer, IProductRepository product)
        {
            _customer = customer;
            _delivery = delivery;
            _discount = discount;
            _ordeer = ordeer;
            _product = product;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.IsValid == false)
            {
                return new GeneratComandResult(false, "Pedido invalido", null);
            }
            //Recupera o cliente
            var customer = _customer.Get(command.Customer);

            //Taxa de entrega
            var deliveryFee = _delivery.Get(command.ZipCode);

            //Obtem o cupom de desconto
            var discount = _discount.Get(command.PromoCode);

            //Gera o pedido
            var products = _product.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }
            AddNotifications(customer.Notifications);
            AddNotifications(order.Notifications);

            //verifica se deu certo
            if (IsValid)
            {
                _ordeer.Save(order);
                return new GeneratComandResult(true, $"Pedido{order.Number} gerado com sucesso", order.ToString());
            }
            else
            {
                return new GeneratComandResult(false, "Falha ao gerar o pedido", null);
            }


        }

    }
}

