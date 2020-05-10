using System.Collections.Generic;
using System.Linq;
using BigDeckPlays.Shared.Models;
using BigDeckPlays.DAL.Repositories;

namespace BigDeckPlays.ApplicationCore.Services
{
    public interface IScryfallService
    {
        IEnumerable<Card> GetCards(IEnumerable<string> cardNames);
        IEnumerable<Set> GetSets();
        IEnumerable<Card> GetBySet(string setCode);
    }
    
    public class ScryfallService : IScryfallService
    {
        private IApiRepository _api;
        private IScryfallRepository _repo;
        
        public ScryfallService(IApiRepository api = null,
                               IScryfallRepository repo = null)
        {
            _api = api ?? new ApiRepository();
            _repo = repo ?? new ScryfallRepository();
            
        }
        
        public IEnumerable<Card> GetCards(IEnumerable<string> cardNames)
        {
            return cardNames.Select(name =>
                    {
                        var url = _repo.GetFuzzyCardUrl(name);
                        return _api.Get<Card>(url);
                    });
        }

        public IEnumerable<Set> GetSets()
        {
            return _repo.GetSets();
        }

        public IEnumerable<Card> GetBySet(string setCode)
        {
            var cards = _repo.GetCardsForSet(setCode).ToList();

            var connectionString = "";
            var dbPassword = "";
 
            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = dbPassword
            };

            using (var db = new DatabaseRepository())
            {
                foreach (var card in cards)
                {
                    db.Cards.Add(card);
                }

                db.SaveChanges();
            }
            
            
            return cards;
        }
    }
}
