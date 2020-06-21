using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Entities
{
    public class PlayerHandler :
    Notifiable,
    IHandler<CreatePlayerCommand>
    {
        private readonly IPlayerRepository _repository;

        public PlayerHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePlayerCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Algo deu errado", command.Notifications);

            //Gera Player
            var player = new Player(command.Email, command.Name, command.NickName, command.Avatar, command.Country);

            //Salva no banco
            _repository.Create(player);

            return new GenericCommandResult(true, "Salvo", player);
        }

    }
}