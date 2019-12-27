using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigDeckPlays.DAL.Mappers;
using BigDeckPlays.Shared.Models;
using Moq;
using System.Collections.Generic;

namespace BigDeckPlays.Tests.DAL.Repositories.InventoryRepository
{
    [TestClass]
    public class TestGetCards : TestInventoryRepository
    {
        [TestMethod]
        public void CallsReadLine_WithGivenPath_AndReturnsConvertedCards()
        {
            var expected_path = "c:/git/mtg/collections/my_collection.csv";
            var expected_cards = new List<Card>
            {
                RandomCard(),
                RandomCard(),
                RandomCard()
            };
            var card_strings = expected_cards.Select(CardMapper.CardToString).ToList();
            _mockFile.Setup(f => f.ReadLines(expected_path)).Returns(card_strings);

            var actual_cards = _repo.GetCards().ToList();

            _mockFile.Verify(f => f.ReadLines(expected_path), Times.Once);
            CollectionAssert.AreEqual(expected_cards, actual_cards);
        }
    }
}
