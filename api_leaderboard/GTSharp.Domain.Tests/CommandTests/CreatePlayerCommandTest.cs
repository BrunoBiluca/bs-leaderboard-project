using GTSharp.Domain.Commands.Input.CreateCommand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreatePlayerCommandTest
    {
        private readonly CreatePlayerCommand _validCommand = new CreatePlayerCommand("Bruce", "Wayne.png", "BR", 1, 1);
        private readonly CreatePlayerCommand _invalidCommand = new CreatePlayerCommand("Wa", null, "Brasil", null, null);
        private readonly CreatePlayerCommand _nullCommand = new CreatePlayerCommand(null, null, null, null, null);

        public CreatePlayerCommandTest()
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