
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.HandlerTests
{

    [TestClass]
    public class CreateUserHandlerTests
    {
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("bruce@gmail.com", "Bruce", "Bat.png", "Batman", "Bat.png", "BR");
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("bruce@gmail", "Wa", null, "Ba", null, "Brasil");
        private readonly CreateUserCommand _nullCommand = new CreateUserCommand(null, null, null, null, null, null);
        private readonly UserHandler _handler = new UserHandler(new UserFakeRepository());

        public CreateUserHandlerTests()
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