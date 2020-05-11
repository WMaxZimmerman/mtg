using System.Collections.Generic;
using System.Linq;
using BigDeckPlays.Shared.Models;
using BigDeckPlays.DAL.db;
using BigDeckPlays.DAL.Repositories;
using BigDeckPlays.DAL.Models;

namespace BigDeckPlays.ApplicationCore.Services
{
    public interface IScryfallService
    {
        IEnumerable<BigDeckPlays.Shared.Models.Card> GetCards(IEnumerable<string> cardNames);
        IEnumerable<BigDeckPlays.Shared.Models.Set> GetSets();
        IEnumerable<BigDeckPlays.Shared.Models.Card> GetBySet(string setCode);
    }
    
    public class ScryfallService : IScryfallService
    {
        private IApiRepository _api;
        private IScryfallRepository _repo;
        private BigDeckPlaysContext _db;
        
        public ScryfallService(IApiRepository api = null,
                               IScryfallRepository repo = null)
        {
            _api = api ?? new ApiRepository();
            _repo = repo ?? new ScryfallRepository();
            _db = new BigDeckPlaysContext();
        }
        
        public IEnumerable<BigDeckPlays.Shared.Models.Card> GetCards(IEnumerable<string> cardNames)
        {
            return cardNames.Select(name =>
                    {
                        var url = _repo.GetFuzzyCardUrl(name);
                        return _api.Get<BigDeckPlays.Shared.Models.Card>(url);
                    });
        }
        
        public IEnumerable<BigDeckPlays.Shared.Models.Card> GetDBCards()
        {
            var cards = _db.Card.AsEnumerable().Select(c => new BigDeckPlays.Shared.Models.Card()
            {
                Name = c.Name,
                Cmc = c.Cmc ?? 0
            });
            
            return cards;
        }

        public IEnumerable<BigDeckPlays.Shared.Models.Set> GetSets()
        {
            return _repo.GetSets();
        }

        public IEnumerable<BigDeckPlays.Shared.Models.Card> GetBySet(string setCode)
        {
            var cards = _repo.GetCardsForSet(setCode).ToList();

            // var connectionString = "";
            // var dbPassword = "";
 
            // var builder = new NpgsqlConnectionStringBuilder(connectionString)
            // {
            //     Password = dbPassword
            // };

            // using (var db = new DatabaseRepository())
            // {
            //     foreach (var card in cards)
            //     {
            //         db.Cards.Add(card);
            //     }

            //     db.SaveChanges();
            // }
            
            
            return cards;
        }
    }
}
