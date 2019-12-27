using Microsoft.VisualStudio.TestTools.UnitTesting;
using repos = BigDeckPlays.DAL.Repositories;
using System.IO;
using System.Text;

namespace BigDeckPlays.Tests.DAL.Repositories.ConsoleRepository
{
    [TestClass]
    public class TestConsoleRepository
    {
        private StringWriter consoleMock;
        protected StringBuilder mockConsole = new StringBuilder();
        protected repos.ConsoleRepository _repo;

        [TestInitialize]
        public void Init()
        {
            consoleMock = new StringWriter(mockConsole);
            System.Console.SetOut(consoleMock);

            _repo = new repos.ConsoleRepository();
        }
    }
}
