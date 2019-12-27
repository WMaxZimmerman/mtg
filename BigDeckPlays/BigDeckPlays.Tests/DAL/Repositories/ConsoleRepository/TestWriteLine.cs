using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BigDeckPlays.Tests.DAL.Repositories.ConsoleRepository
{
    [TestClass]
    public class TestWriteLine : TestConsoleRepository
    {
        [TestMethod]
        public void WriteLine_OutputsLineToConsole()
        {
            var message = "hello world";
            var expectedMessage = message + Environment.NewLine;
            _repo.WriteLine(message);

            Assert.AreEqual(expectedMessage, mockConsole.ToString());
        }
    }
}
