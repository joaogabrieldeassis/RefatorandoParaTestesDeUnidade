using System.Diagnostics.Contracts;
using System.Windows.Input;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        CreateOrderItemCommand() { }
        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public event EventHandler? CanExecuteChanged;

        public void Validate()
        {
            AddNotifications(new Contract<CreateOrderItemCommand>()
            .Requires()
            .HasLen(Product.ToString(), 32, "Product", "Produto invalido")
            .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade invalida")
            );
        }


        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}