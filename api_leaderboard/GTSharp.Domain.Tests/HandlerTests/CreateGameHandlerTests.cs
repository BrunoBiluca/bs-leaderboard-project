
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.HandlerTests
{

    [TestClass]
    public class CreateGameHandlerTests
    {
        private readonly CreateGameCommand _validCommand = new CreateGameCommand("Batman", "Hero");
        private readonly CreateGameCommand _invalidCommand = new CreateGameCommand("Mu", "B");
        private readonly CreateGameCommand _nullCommand = new CreateGameCommand(null, null);
        private readonly GameHandler _handler = new GameHandler(new GameFakeRepository());

        public CreateGameHandlerTests()
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