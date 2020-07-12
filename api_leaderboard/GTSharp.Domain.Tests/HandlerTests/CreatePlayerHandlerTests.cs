
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.HandlerTests
{

    [TestClass]
    public class CreatePlayerHandlerTests
    {
        private readonly CreatePlayerCommand _validCommand = new CreatePlayerCommand("Bruce", "Wayne.png", "BR", 1, 1);
        private readonly CreatePlayerCommand _invalidCommand = new CreatePlayerCommand("Wa", null, "Brasil", null, null);
        private readonly CreatePlayerCommand _nullCommand = new CreatePlayerCommand(null, null, null, null, null);
        private readonly PlayerHandler _handler = new PlayerHandler(new PlayerFakeRepository());

        public CreatePlayerHandlerTests()
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