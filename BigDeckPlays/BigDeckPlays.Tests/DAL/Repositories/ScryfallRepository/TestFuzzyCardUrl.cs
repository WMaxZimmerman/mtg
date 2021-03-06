using Microsoft.VisualStudio.TestTools.UnitTesting;
using repos = BigDeckPlays.DAL.Repositories;

namespace BigDeckPlays.Tests.DAL.Repositories.ScryfallRepository
{
    [TestClass]
    public class TestGetFuzzyCardUrl: TestScryfallRepository
    {
        private string _baseUrl;
        
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            _baseUrl = $"{repos.ScryfallRepository.HostUrl}cards/named?fuzzy=";
        }

        [TestMethod]
        public void GetFuzzyCardUrl_ReturnsCorrectUrl_WhenNoSpaces()
        {
            var card = "opt";
            var expectedUrl = $"{_baseUrl}{card}";

            var actual = _repo.GetFuzzyCardUrl(card);

            Assert.AreEqual(expectedUrl, actual);
        }

        [TestMethod]
        public void GetFuzzyCardUrl_ReturnsCorrectUrl_WhenSpaces()
        {
            var card = "sol ring";
            var expectedUrl = $"{_baseUrl}{card.Replace(' ', '+')}";

            var actual = _repo.GetFuzzyCardUrl(card);

            Assert.AreEqual(expectedUrl, actual);
        }
    }
}
