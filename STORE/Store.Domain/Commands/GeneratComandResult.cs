using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class GeneratComandResult : ICommandResult
    {
        public GeneratComandResult(bool sucesso, string message, string data)
        {
            Sucesso = sucesso;
            Message = message;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}