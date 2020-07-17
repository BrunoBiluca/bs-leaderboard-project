using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

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
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Player
            var player = new Player(command.NickName, command.Avatar, command.Country, command.IdUser, command.IdGame);

            //Salva no banco
            _repository.Create(player);

            return new GenericCommandResult(true, Messages.Act_Save, player);
        }
    }
}