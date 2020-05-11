using System.Collections.Generic;
using System.Linq;
using BigDeckPlays.Shared.Models;
using BigDeckPlays.DAL.Repositories;

namespace BigDeckPlays.ApplicationCore.Services
{
    public interface ICardService
    {
        IEnumerable<Card> GetFromDatabase();
    }
    
    public class CardService : ICardService
    {
        private IDatabaseRepository _db;
        private IScryfallRepository _api;
        
        public CardService(IDatabaseRepository db = null, IScryfallRepository api = null)
        {
            _db = db ?? new DatabaseRepository();
            _api = api ?? new ScryfallRepository();
        }
        
        public IEnumerable<Card> GetFromDatabase()
        {
            return _db.Cards();
        }
    }
}
