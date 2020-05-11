using BigDeckPlays.DAL.Mappers;
using BigDeckPlays.DAL.Models;
using BigDeckPlays.Shared.Models;
using System.Collections.Generic;
using System.Linq;

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
            var result = _api.Get<ScryfallContainer<ApiSet>>(url);

            return result.Data.Select(SetMapper.ApiToShared);
        }

        public IEnumerable<Card> GetCardsForSet(string setCode)
        {
            var url = HostUrl + $"cards/search?order=set&q=e%3A{setCode}&unique=prints&page=";
            var hasMore = true;
            var cards = new List<ApiCard>();
            var page = 1;

            while (hasMore)
            {
                var pagedUrl = url + page;
                var result = _api.Get<ScryfallContainer<ApiCard>>(pagedUrl);

                cards.AddRange(result.Data);
                hasMore = result.Data.Count > 0;
                page++;
            }

            return cards.Select(CardMapper.ApiToShared);
        }
    }
}
