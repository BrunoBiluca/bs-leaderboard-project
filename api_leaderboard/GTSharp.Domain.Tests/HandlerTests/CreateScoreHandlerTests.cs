
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.HandlerTests
{

    [TestClass]
    public class CreateScoreHandlerTests
    {
        private readonly CreateScoreCommand _validCommand = new CreateScoreCommand("Fase 1", 1, 30, null, 1, 1);
        private readonly CreateScoreCommand _invalidCommand = new CreateScoreCommand("F1", -1, -2, null, 1, 1);
        private readonly CreateScoreCommand _nullCommand = new CreateScoreCommand(null, null, null, null, null, null);

        private readonly ScoreHandler _handler = new ScoreHandler(new ScoreFakeRepository());

        public CreateScoreHandlerTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
            _nullCommand.Validate();
        }

        [TestMethod]
        public void ValidCommandToHandler()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public void InvalidCommandToHandler()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void InvalidNullCommandToHandler()
        {
            var result = (GenericCommandResult)_handler.Handle(_nullCommand);
            Assert.AreEqual(result.Success, false);
        }

    }
}