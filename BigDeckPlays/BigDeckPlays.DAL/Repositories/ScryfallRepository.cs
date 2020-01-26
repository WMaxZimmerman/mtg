using BigDeckPlays.Shared.Models;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.Repositories
{
    public interface IScryfallRepository
    {
        string GetFuzzyCardUrl(string card);
        IEnumerable<Set> GetSets();
        IEnumerable<Card> GetCardsForSet(string setCode);
    }
    
    public class ScryfallRepository : IScryfallRepository
    {
        private IApiRepository _api;
        public const string HostUrl = "https://api.scryfall.com/";
        
        public ScryfallRepository()
        {
            _api = new ApiRepository();
        }

        public string GetFuzzyCardUrl(string card)
        {
            var baseurl = HostUrl + "cards/named?fuzzy=";
            var parsedName = card.Replace(' ', '+');

            return baseurl + parsedName;
        }

        public IEnumerable<Set> GetSets()
        {
            var url = HostUrl + "sets";
            var data = _api.Get<ScryfallContainer<Set>>(url);

            return data.Data;
        }

        public IEnumerable<Card> GetCardsForSet(string setCode)
        {
            var url = HostUrl + $"cards/search?order=set&q=e%3A{setCode}&unique=prints&page=";
            var hasMore = true;
            var cards = new List<Card>();
            var page = 1;

            while (hasMore)
            {
                var pagedUrl = url + page;
                var result = _api.Get<ScryfallContainer<Card>>(pagedUrl);

                cards.AddRange(result.Data);
                hasMore = result.Data.Count > 0;
                page++;
            }

            return cards;
        }
    }
}
