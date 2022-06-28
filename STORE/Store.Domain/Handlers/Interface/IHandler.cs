using System.Windows.Input;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Handlers.Interface
{
    public interface IHandler<T> where T : ICommands
    {
        ICommandResult Handle(T command);
    }
}