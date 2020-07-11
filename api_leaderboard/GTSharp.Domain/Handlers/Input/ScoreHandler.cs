using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class ScoreHandler :
    Notifiable,
    IHandler<CreateScoreCommand>
    {
        private readonly IScoreRepository _repository;

        public ScoreHandler(IScoreRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateScoreCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Score
            var Score = new Score(command.Title, command.Stage, command.Value, command.CreateDate, command.PlayerId);

            //Salva no banco
            _repository.Create(Score);

            return new GenericCommandResult(true, Messages.Act_Save, Score);
        }
    }
}