using GTSharp.Domain.Commands.Input.CreateCommand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateGameCommandTest
    {
        private readonly CreateGameCommand _validCommand = new CreateGameCommand("Batman", "Hero");
        private readonly CreateGameCommand _invalidCommand = new CreateGameCommand("Mu", "B");
        private readonly CreateGameCommand _nullCommand = new CreateGameCommand(null, null);

        public CreateGameCommandTest()
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