using GTSharp.Domain.Commands.Input.CreateCommand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateUserCommandTest
    {
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("bruce@gmail.com", "Bruce", "Bat.png", "Batman", "Bat.png", "BR");
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("bruce@gmail", "Wa", null, "Ba", null, "Brasil");
        private readonly CreateUserCommand _nullCommand = new CreateUserCommand(null, null, null, null, null, null);

        public CreateUserCommandTest()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
            _nullCommand.Validate();
        }

        [TestMethod]
        public void ValidCommand()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void NullCommand()
        {
            Assert.AreEqual(_nullCommand.Valid, false);
        }
    }
}