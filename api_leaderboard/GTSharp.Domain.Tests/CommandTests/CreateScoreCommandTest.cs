using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTSharp.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateScoreCommandTest
    {
        private readonly CreateScoreCommand _validCommand = new CreateScoreCommand("Fase 1", "1", 30, null, 1, 1);
        private readonly CreateScoreCommand _invalidCommand = new CreateScoreCommand("F1", "", -2, null, 1, 1);
        private readonly CreateScoreCommand _nullCommand = new CreateScoreCommand(null, null, null, null, null, null);

        public CreateScoreCommandTest()
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