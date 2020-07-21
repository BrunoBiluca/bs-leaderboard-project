using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class GameHandler :
    Notifiable,
    IHandler<CreateGameCommand>
    {
        private readonly IGameRepository _repository;

        public GameHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateGameCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Game
            var Game = new Game(command.Title, command.Genre);

            //Salva no banco
            _repository.Create(Game);

            return new GenericCommandResult(true, Messages.Act_Save, Game);
        }
    }
}