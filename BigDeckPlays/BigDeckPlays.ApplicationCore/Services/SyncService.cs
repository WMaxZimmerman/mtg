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
            var apiSets = _scryfall.GetSets().Where(s => s.SetType != "funny").ToList();
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
    }
}
