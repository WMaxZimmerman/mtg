using System.Collections.Generic;
using System.Linq;
using BigDeckPlays.DAL.Mappers;
using BigDeckPlays.Shared.Models;

namespace BigDeckPlays.DAL.Repositories
{
    public interface IInventoryRepository
    {
        void AddCards(IEnumerable<Card> cards);
        IEnumerable<Card> GetCards();
    }
    
    public class InventoryRepository : IInventoryRepository
    {
        private IFileRepository _fileRepo;
        public const string  _path = "c:/git/mtg/collections/my_collection.csv";
        public const string  _writePath = "c:/git/mtg/collections/my_collection_temp.csv";

        
        public InventoryRepository(IFileRepository fileRepo = null)
        {
            _fileRepo = fileRepo ?? new FileRepository();
        }
        
        public void AddCards(IEnumerable<Card> cards)
        {
            var carString = cards.Select(CardMapper.CardToString);
            _fileRepo.WriteLines(carString, _writePath);
        }

        public IEnumerable<Card> GetCards()
        {
            return _fileRepo.ReadLines(_path).Select(CardMapper.StringToCard);
        }
    }
}
