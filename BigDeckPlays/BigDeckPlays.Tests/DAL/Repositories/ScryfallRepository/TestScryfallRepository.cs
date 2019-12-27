using Microsoft.VisualStudio.TestTools.UnitTesting;
using repos = BigDeckPlays.DAL.Repositories;
using Moq;

namespace BigDeckPlays.Tests.DAL.Repositories.ScryfallRepository
{
    [TestClass]
    public class TestScryfallRepository
    {
        protected Mock<repos.IApiRepository> _mockApi;
        
        protected repos.ScryfallRepository _repo;

        [TestInitialize]
        public virtual void Init()
        {
            _repo = new repos.ScryfallRepository();
        }
    }
}
