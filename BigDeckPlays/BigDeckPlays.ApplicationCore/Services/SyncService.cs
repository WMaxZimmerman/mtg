using System.Collections.Generic;
using System.Linq;
using BigDeckPlays.DAL.Mappers;
using BigDeckPlays.DAL.Repositories;

namespace BigDeckPlays.ApplicationCore.Services
{
    public interface ISyncService
    {
        void SyncSets();
    }
    
    public class SyncService : ISyncService
    {
        private IScryfallService _scryfall;
        private IDatabaseRepository _db;
        
        public SyncService(IScryfallService scryfall = null,
                           IDatabaseRepository db = null)
        {
            _scryfall = scryfall ?? new ScryfallService();
            _db = db ?? new DatabaseRepository();
        }
        
        public void SyncSets()
        {
            var excludedTypes = new List<string>
            {
                "funny",
                "token"
            };
            var apiSets = _scryfall.GetSets().Where(s => !excludedTypes.Contains(s.SetType)).ToList();
            System.Console.WriteLine($"found {apiSets.Count} sets from API");
            var dbSets = _db.Sets().ToList();
            System.Console.WriteLine($"found {dbSets.Count} sets from DB");
            var setsToAdd = apiSets.Where(a => !dbSets.Any(d => d.Id == a.Id));

            foreach (var newSet in setsToAdd)
            {
                System.Console.WriteLine($"Attempting to add set '{newSet.Name}'");
                _db.AddSet(SetMapper.SharedToDb(newSet));
            }
        }
        
        public void SyncCards()
        {
            var sets = _db.Sets().OrderBy(s => s.ReleasedAt);

            foreach (var dbSet in sets)
            {
                if (dbSet.Completed == false)
                {
                    System.Console.WriteLine($"attempting to sync cards for the set {dbSet.Name}");
                    var cards = _scryfall.GetBySet(dbSet.Code).ToList();
                    System.Console.WriteLine($"syncing {dbSet.CardCount} cards for the set {dbSet.Name}");
                    foreach (var card in cards)
                    {
                        _db.AddCard(CardMapper.SharedToDb(card), SetMapper.SharedToDb(dbSet));
                    }
                    _db.CompleteSet(dbSet);
                }
                else
                {
                    System.Console.WriteLine($"Skipping the set {dbSet.Name}");
                }                
            }
        }
    }
}
