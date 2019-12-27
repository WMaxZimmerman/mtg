using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigDeckPlays.DAL.Mappers;
using BigDeckPlays.Shared.Models;
using Moq;
using System.Collections.Generic;

namespace BigDeckPlays.Tests.DAL.Repositories.InventoryRepository
{
    [TestClass]
    public class TestAddCards : TestInventoryRepository
    {
        [TestMethod]
        public void CallsWriteLines_WithConvertedCards()
        {
            var expected_path = "c:/git/mtg/collections/my_collection_temp.csv";
            var cards = new List<Card>
            {
                RandomCard(),
                RandomCard(),
                RandomCard()
            };
            var expected_cards = cards.Select(CardMapper.CardToString).ToList();

            _repo.AddCards(cards);

            _mockFile.Verify(f => f.WriteLines(expected_cards, expected_path), Times.Once);
        }
    }
}
