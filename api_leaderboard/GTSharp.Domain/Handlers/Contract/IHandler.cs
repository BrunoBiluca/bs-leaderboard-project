using GTSharp.Domain.Commands;

namespace GTSharp.Domain.Handlers.Contract
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}